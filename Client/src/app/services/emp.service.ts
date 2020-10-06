import { IEmployee } from './../models/IEmployee';
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
export class EmpService {

  private serverUrl = "https://localhost:5001/api/employee";

  constructor(private http:HttpClient,private jwttoken:JWTTokenServiceService,private localstore:LocalStorageServiceService,private router:Router) { }
  user:string=null;
  id:string = localStorage.getItem('userid');
  getlist(): Observable<any>{
    return this.http.get<any>(this.serverUrl+"/employeelist",{
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

  addemployee(form:IEmployee): Observable<any>{
    const url = `${this.serverUrl+"/add"}/${this.id}`;
    return this.http.post<any>(url,form,{
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

  editemployee(dep:IEmployee): Observable<any>{
    // const url = `${this.serverUrl}`;
     return this.http.put<any>(this.serverUrl+"/edit",dep,{
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

   updateemployee(dep:IEmployee): Observable<any>{
    // const url = `${this.serverUrl}`;
    const url = `${this.serverUrl+"/update"}/${this.id}`;
     return this.http.put<any>(url,dep,{
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

 deleteemployee(id:string): Observable<any>{
   const url = `${this.serverUrl}/${id}`;
    return this.http.delete<any>(url,{
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
