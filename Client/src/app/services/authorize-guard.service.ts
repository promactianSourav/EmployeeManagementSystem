import { AuthServiceService } from './auth-service.service';
import { JWTTokenServiceService } from './jwttoken-service.service';
import { LocalStorageServiceService } from './local-storage-service.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, RouterModule, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeGuardService implements CanActivate {

  constructor(private auth: AuthServiceService,
    private authStorageService: LocalStorageServiceService,
    private jwtService: JWTTokenServiceService,private router:Router) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<any> | Promise<any> | boolean {
    if (this.jwtService.getUser()) {
      if (this.jwtService.isTokenExpired()) {
        // Should Redirect Sig-In Page
        this.router.navigateByUrl('/login');
      } else {
        return true;
      }
    }
    //  else {
    //   return new Promise((resolve) => {
    //     this.auth.signIncallBack().then((e) => {
    //       resolve(true);
    //     }).catch((e) => {
    //       // Should Redirect Sign-In Page
    //     });
    //   });
    }
  }
