import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError,tap } from 'rxjs/operators';
import { JWTTokenServiceService } from './jwttoken-service.service';
import { LocalStorageServiceService } from './local-storage-service.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private serverUrl = "https://localhost:5001/api/notification";

  constructor(private http:HttpClient,private jwttoken:JWTTokenServiceService,private localstore:LocalStorageServiceService,private router:Router) { }
  user:string=null;
   userId:string = localStorage.getItem('userid');
   url:string = null;
  getnotification(): Observable<any>{
    
    
    console.log("useridnotif"+this.userId);
   this.url = `${this.serverUrl}/${this.userId}`;
    return this.http.get<any>(this.url,{
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      })
    }).pipe(
      tap(data => {
        JSON.stringify(data);
        console.log(data);
      }),
      catchError(this.handleError)
    );
  }

  readnotification(Id:string): Observable<any>{
    const userId = sessionStorage.getItem('userid');
    const url = `${this.serverUrl}/${Id}/${userId}`;
    return this.http.get<any>(url,{
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      })
    }).pipe(
      tap(data => {
        JSON.stringify(data);
        console.log(data);
      }),
      catchError(this.handleError)
    );
  }

  // adddepart(form:IDepartment): Observable<any>{
  //   return this.http.post<any>(this.serverUrl+"/add",form,{
  //     headers: new HttpHeaders({
  //       'Content-Type':'application/json'
  //     })
  //   }).pipe(
  //     tap(data => {
  //       JSON.stringify(data);
  //       console.log(data);
  //     }),
  //     catchError(this.handleError)
  //   );
  // }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occured: ${err.error.message}`;
    } else {
      errorMessage = `Server return code: ${err.status}, error message is: ${err.message}`;
      if(err.status==403){
        localStorage.setItem('erCode','403');
      }
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
