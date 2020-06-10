/*import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { authService } from 'src/app/Services/authService';
import { Injectable } from '@angular/core';

@Injectable()
export class LoginCheckActivate implements CanActivate {
  route: ActivatedRouteSnapshot;
  state: RouterStateSnapshot;
  constructor(private authService: authService, private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Promise<boolean> {
    this.route = route;
    this.state = state;
    console.log("GuardCheck Path:" + this.route.routeConfig.path)
    return new Promise<boolean>((resolve, reject) => {
      this.authService.isLoggedIn().then(o => {
        if (!o) {
          return resolve(this.fail());
        }
        return resolve(this.success());
      })
    })
  }
  success() {
    if (this.route.routeConfig.path != "login") {
      console.log("Giriş yapılmış, sayfaya yönlendir");
      return true;
    }
    console.log("Giriş yapılmış, login sayfasına gidemez");
    this.router.navigate(['']);
    return false;
  }
  fail(): boolean {
    console.log("Giriş yapılmamış, login sayfasına gider");
    if (this.route.routeConfig.path == "login") {
      return true;
    }
    this.router.navigate(['login']);
    return false;

  }
  redirectToLogin() {
    debugger;

    console.warn("Redirected to LOGIN");

  }
}*/
