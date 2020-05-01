import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AppApi } from "../app.api";
import { retry, catchError, tap, mapTo } from "rxjs/operators";
import { NotificationService } from "../shared/notification.service";
import { of, Observable } from "rxjs";
import { TokenAndRefreshToken } from "../results/user/TokenAndRefreshToken.model";
import { LoginUserCommand } from "../commands/user/LoginUserCommand.model";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private readonly JWT_TOKEN = "acT";
  private readonly REFRESH_TOKEN = "acRT";
  private readonly COMPANY_NAME = "acCN";
  private readonly COMPANY_LOGO = "acCL";
  private readonly EMPLOYEE_NAME = "acEN";
  private readonly EMPLOYEE_ID = "acEI";
  private readonly EMPLOYEE_EMAIL = "acEE";
  private loggedUser: string;

  constructor(private http: HttpClient) { }

  login(user: { username: string; password: string }): Observable<boolean> {
    const loginCommand = new LoginUserCommand();
    loginCommand.UsernameOrEmail = user.username;
    loginCommand.Password = user.password;
    loginCommand.Source = 0;
    return this.http
      .post<any>(
        `${AppApi.MobileControlApiResourceUserProfile}/v1/Login`,
        loginCommand
      )
      .pipe(
        tap((tokens) => this.doLoginUser(user.username, tokens)),
        retry(2),
        //mapTo(true),
        catchError((error) => {
          alert(error.error);
          return of(false);
        })
      );
  }

  //NOTE BY FERNANDO: TO TEST API (the test-method on the backend), YOU CAN CHANGE THE CALL ON login.component.ts
  testApi() {
    //Note: token will be added by the HttpInterceptor, and UserProfile will be taken by the Token
    return this.http
      .get(`${AppApi.MobileControlApiResourceUserProfile}/v1/test`)
      .pipe(
        tap((response) => alert(response)),
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  getUserProfileClaims() {
    //Note: token will be added by the HttpInterceptor, and UserProfile will be taken by the Token
    return this.http
      .get(
        `${AppApi.MobileControlApiResourceUserProfile}/v1/GetUserProfileClaims`
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  getUserProfiles() {
    //Note: token will be added by the HttpInterceptor, and UserProfile will be taken by the Token
    return this.http
      .get(`${AppApi.MobileControlApiResourceUserProfile}/v1`)
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  logout() {
    //NOTE: In the future i can implement here something to also do logout on BackEnd
    //I don't know, remove the RefreshToken, do some LOG, i don't know
    // return this.http.post<any>(`${MobileControlApiResourceUserProfile}v1/Login`, {
    //     'refreshToken': this.getRefreshToken()
    // }).pipe(
    //     tap(() => this.doLogoutUser()),
    //     mapTo(true),
    //     catchError(error => {
    //         alert(error.error);
    //         return of(false);
    //     })
    // );

    this.doLogoutUser();
  }

  isLoggedIn() {
    return !!this.getJwtToken();
  }

  refreshToken() {
    return this.http
      .post<any>(`${AppApi.MobileControlApiResourceUserProfile}/v1/Login/rt`, {
        refreshToken: this.getRefreshToken(),
      })
      .pipe(
        tap((tokens: TokenAndRefreshToken) => {
          this.storeJwtToken(tokens);
        })
      );
  }

  // refreshToken() {
  //     return this.http.post<any>(`${MobileControlApiResourceUserProfile}v1/Login/rt`, {
  //         'refreshToken': this.getRefreshToken()
  //     }).pipe(tap((tokens: TokenAndRefreshToken) => {

  //         this.storeJwtToken(tokens.token);
  //     }));
  // }

  private doLoginUser(username: string, tokens: any) {
    this.loggedUser = username;
    this.storeTokens(tokens);
  }

  private doLogoutUser() {
    this.loggedUser = null;
    this.removeTokens();
  }

  getJwtToken() {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  getRefreshToken() {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }

  private storeJwtToken(tokens) {
    this.storeTokens(tokens);
  }

  private storeTokens(tokens: any) {
    if (tokens.Success) {
      localStorage.setItem(this.JWT_TOKEN, tokens.ResponseDataObj.token);
      localStorage.setItem(
        this.REFRESH_TOKEN,
        tokens.ResponseDataObj.refreshToken
      );
      localStorage.setItem(
        this.COMPANY_NAME,
        tokens.ResponseDataObj.companyName
      );
      localStorage.setItem(
        this.COMPANY_LOGO,
        tokens.ResponseDataObj.companyLogoUrl
      );
      localStorage.setItem(
        this.EMPLOYEE_NAME,
        tokens.ResponseDataObj.employeeName
      );
      localStorage.setItem(this.EMPLOYEE_ID, tokens.ResponseDataObj.employeeId);
      localStorage.setItem(
        this.EMPLOYEE_EMAIL,
        tokens.ResponseDataObj.employeeEmail
      );
    } else {
      NotificationService.showNotification(
        "warning",
        "top",
        "right",
        "Não é possível logar.",
        "Usuário ou Senha não correspondem."
      );
    }
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
    localStorage.removeItem(this.COMPANY_NAME);
    localStorage.removeItem(this.EMPLOYEE_NAME);
    localStorage.removeItem(this.EMPLOYEE_ID);
    localStorage.removeItem(this.COMPANY_LOGO);
    localStorage.removeItem(this.EMPLOYEE_EMAIL);
  }

  //This Method will Receive the "Role" (taken on the Route File by Auth.Guard) and Check if the User
  //have the Specific Claim on the Token or Not... basically - look for image 14 to see how it works
  //Note: Image 14,15,16 show very well how all this system works!
  roleMatch(allowedRoles): boolean {
    if (this.getJwtToken() != null) {
      var isMatch = false;
      var payLoad = JSON.parse(window.atob(this.getJwtToken().split(".")[1]));
      var userRoles = payLoad.roles as Array<string>;
      allowedRoles.forEach((element) => {
        userRoles.forEach((userRole) => {
          if (userRole == element) {
            isMatch = true;
            return false;
          }
        });
      });
      return isMatch;
    }
    return false;
  }
}
