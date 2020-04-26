// This class will check if the Link can be activated (based on the roles)

import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree {
    //I`ll check if the token exists, if false, I'll redirect the usr to the Login
    if (this.authService.isLoggedIn() != null) {
      let roles = next.data['permittedRoles'] as Array<string>; //i convert to array because inside routing it's an array...      
      if (roles) { //if there are any routes, I`ll handle in the if
        if (this.authService.roleMatch(roles)) {
          return true; //to check if the user has the roles, I'll do it inside the UserProfile Service
        }
        else { //if there arent roles, I will redirect to forbidden
          this.router.navigate(['/forbidden']);
          return false;
        }
      }
      return true;
    }
    else {
      this.router.navigate(['/pages/login']);
    }
  }

  // canActivate() {
  //   if (this.authService.isLoggedIn()) {      
  //     //this.router.navigate(['/secret-random-number']);
  //   }

  //   return !this.authService.isLoggedIn();
  // }
}