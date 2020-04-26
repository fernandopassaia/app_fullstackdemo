// This class will intercept the Request and Add the Token. Will also handle if API return 401 (Unauthorized) or 403 (Forbidden)

import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { catchError, filter, take, switchMap, retry, map } from 'rxjs/operators';
import { AuthService } from 'src/app/services/auth.service';
import { NotificationService } from '../../shared/notification.service';
import { BaseCommandResult } from 'src/app/models/BaseCommandResult.model';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    private isRefreshing = false;
    private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

    constructor(private authService: AuthService) {
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        //Note By Fernando: I need to Check if Form contains Multi-Part/FormData (for example, if a file was attached)
        //and inser a Header of MultiForm. If Not, it's just a JSON in the body, we will send application/json header.
        if (request.body instanceof FormData) {
            //console.log("Yeah, catch FormData");
            //Note by Fernando: It's enought to not add any header in case of files in multi-part body, so, will do nothing
        }
        else {
            //console.log("Not FormData, just Json.");
            if (this.authService.getJwtToken()) {
                request = this.addHeaderToken(request, this.authService.getJwtToken());
            } else {
                request = this.addHeaderWithoutToken(request);
            }
        }

        return next.handle(request).pipe(
            retry(2),
            map((res: HttpResponse<any>) => {
                if (res.status == 200) {
                    //if returns 200, the BackEnd operation is OK... but i have to enter the model (BaseCommandResult) and
                    //check the "Success" (true or false): Based on that I'll show the proper message to the UI                    
                    if (res.body.Success != undefined) {
                        let baseCommandResult = res.body as BaseCommandResult; //convert the baseCommandResult                        
                        if (baseCommandResult.Success == true) {
                            NotificationService.showNotification('success', 'top', 'right', 'Sucesso', res.body.Message);
                        }
                        else {
                            //Note: The BackEnd will return 400 just when there is an exception. In case of validation errors or backend message, it will return an 200 OK
                            //(because the backend don't generate an error) but with a "False" on the Success boolean flag, and the respective message to fix the errors.
                            //FrontEnd apps should intercept the flag, and show the respective message to the user. So 200 but "false" on Success is an error that should be
                            //fixed by the User. Remember that inside the "Errors" there is an array, that i should open and get all errors, showing them to user
                            let erros = "";
                            baseCommandResult.ResponseDataObj.forEach(item => {
                                erros = erros + '<br />' + item.Message;
                            })
                            NotificationService.showNotification('warning', 'top', 'right', 'Erro: ' + res.body.Message, erros);
                        }
                    }
                }
                return res;
            }),
            catchError(error => {
                if (error instanceof HttpErrorResponse && error.status === 401) {
                    return this.handle401Error(request, next);
                }
                if (error instanceof HttpErrorResponse && error.status === 403) {
                    return this.handle403Error(request, next);
                }
                else {
                    return throwError(error);
                }
            }));
    }

    private addHeaderToken(request: HttpRequest<any>, token: string) {
        return request.clone({
            setHeaders: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': '*',
                'Authorization': `Bearer ${token}`
            }
        });
    }

    private addHeaderWithoutToken(request: HttpRequest<any>) {
        return request.clone({
            setHeaders: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': '*',
            }
        });
    }

    private addHeaderFormDataToken(request: HttpRequest<any>, token: string) {
        return request.clone({
            setHeaders: {
                'Content-Type': 'multipart/form-data'
            }
        });
    }

    private addHeaderFormDataWithoutToken(request: HttpRequest<any>) {
        return request.clone({
            setHeaders: {
                'Content-Type': 'multipart/form-data'
            }
        });
    }

    private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
        console.log('401!');
        if (!this.isRefreshing) {
            this.isRefreshing = true;
            this.refreshTokenSubject.next(null);

            return this.authService.refreshToken().pipe(
                switchMap((token: any) => {
                    this.isRefreshing = false;
                    this.refreshTokenSubject.next(token.jwt);
                    return next.handle(this.addHeaderToken(request, token.jwt));
                }));

        } else {
            return this.refreshTokenSubject.pipe(
                filter(token => token != null),
                take(1),
                switchMap(jwt => {
                    return next.handle(this.addHeaderToken(request, jwt));
                }));
        }
    }

    private handle403Error(request: HttpRequest<any>, next: HttpHandler) {
        console.log('403!');
        if (!this.isRefreshing) {
            this.isRefreshing = true;
            this.refreshTokenSubject.next(null);

            return this.authService.refreshToken().pipe(
                switchMap((token: any) => {
                    this.isRefreshing = false;
                    this.refreshTokenSubject.next(token.jwt);
                    return next.handle(this.addHeaderToken(request, token.jwt));
                }));

        } else {
            return this.refreshTokenSubject.pipe(
                filter(token => token != null),
                take(1),
                switchMap(jwt => {
                    return next.handle(this.addHeaderToken(request, jwt));
                }));
        }
    }
}