import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AppApi } from "../app.api";
import { retry, catchError } from "rxjs/operators";
import { CreateUserCommand } from "../commands/user/CreateUserCommand.model";
import { of } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class UserService {
    headers = {
        headers: new HttpHeaders({
            "Content-Type": "application/json",
        }),
    };

    constructor(private http: HttpClient) { }

    initializeFormGroup() { }

    createUser(command: CreateUserCommand) {
        return this.http
            .post(
                `${AppApi.MobileControlApiResourceUser}/v1`,
                JSON.stringify(command),
                this.headers
            )
            .pipe(
                retry(2), //if something happens, will retry 2x
                catchError((err) => {
                    return of(null); //if exception happens, i'll return null
                })
            );
    }
}
