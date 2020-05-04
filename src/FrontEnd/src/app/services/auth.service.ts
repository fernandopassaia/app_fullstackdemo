import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AppApi } from "../app.api";
import { retry, catchError, tap } from "rxjs/operators";
import { of, Observable } from "rxjs";
import { LoginUserCommand } from "../commands/user/LoginUserCommand.model";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private readonly JWT_TOKEN = "appFullStackDemoTK";
  private readonly USERNAME = "appFullStackDemoUN";
  private readonly USEREMAIL = "appFullStackDemoEM";
  private readonly USERID = "appFullStackDemoUI";
  private loggedUser: string;

  constructor(private http: HttpClient) { }

  login(user: { username: string; password: string }): Observable<boolean> {
    const loginCommand = new LoginUserCommand();
    loginCommand.UserName = user.username;
    loginCommand.Password = user.password;
    return this.http
      .post<any>(
        `${AppApi.MobileControlApiResourceUser}/v1/Login`,
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
      .get(`${AppApi.MobileControlApiResourceUser}/v1/test`)
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
        `${AppApi.MobileControlApiResourceUser}/v1/GetUserProfileClaims`
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
      .get(`${AppApi.MobileControlApiResourceUser}/v1`)
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  logout() {
    this.doLogoutUser();
  }

  isLoggedIn() {
    return !!this.getJwtToken();
  }

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

  private storeTokens(tokens: any) {
    if (tokens.Success) {
      localStorage.setItem(this.JWT_TOKEN, tokens.ResponseDataObj.Token);
      //private readonly USERNAME = "appFullStackDemoUN";
      //private readonly USEREMAIL = "appFullStackDemoEM";
      //private readonly USERID = "appFullStackDemoUI";
      localStorage.setItem(
        this.USERNAME,
        tokens.ResponseDataObj.UserName
      );
      localStorage.setItem(
        this.USEREMAIL,
        tokens.ResponseDataObj.UserEmail
      );
      localStorage.setItem(
        this.USERID,
        tokens.ResponseDataObj.UserId
      );
    }
  }

  private removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.USERNAME);
    localStorage.removeItem(this.USEREMAIL);
    localStorage.removeItem(this.USERID);
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
