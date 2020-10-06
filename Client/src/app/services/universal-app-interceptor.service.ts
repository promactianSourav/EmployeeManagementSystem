import { Observable } from 'rxjs';
import { AuthServiceService } from './auth-service.service';

import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class UniversalAppInterceptorService implements HttpInterceptor{


 
  constructor( private authService: AuthServiceService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler):Observable<HttpEvent<any>> {
    const token = localStorage.getItem('token');
    req = req.clone({
      
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next.handle(req);
  }
}
