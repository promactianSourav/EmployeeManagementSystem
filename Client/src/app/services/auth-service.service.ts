import { IEmail } from './../models/IEmail';
import { IResetpasswordview } from './../models/IResetpasswordview';
import { ILoginview } from './../models/ILoginview';
import { LocalStorageServiceService } from './local-storage-service.service';
import { JWTTokenServiceService } from './jwttoken-service.service';
import { HttpClient, HttpClientModule ,HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable ,throwError,pipe} from 'rxjs';
import {catchError,tap,map} from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {


  private serverUrl = "https://localhost:5001/api/security";

  constructor(private http:HttpClient,private jwttoken:JWTTokenServiceService,private localstore:LocalStorageServiceService,private router:Router) { }
  user:string=null;
  login(form:ILoginview): Observable<any>{
    return this.http.post<any>(this.serverUrl+"/login",form,{
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      })
    }).pipe(
      tap(data => {JSON.stringify(data);
        console.log(data);
        this.user = data.username;
          this.localstore.set('token',data.token);
        this.localstore.set('username',data.username);
      }
      ),
      catchError(this.handleError)
    );
  }

  logout():void{
    this.localstore.remove('token');
    this.user=null;
  }

  check():Observable<any>{
    console.log(localStorage.getItem('token'));
    return this.http.get(this.serverUrl+"/check",{responseType:'text'}).pipe(
      tap(data => console.log(data+"sourav")
      ),
      catchError(this.handleError)
    );
  }
  EmailTry:IEmail = {email:null};
  code:string=null;
  forgotpassword(email:string):Observable<any>{
    console.log(localStorage.getItem('token'));
    this.EmailTry.email=email;
    return this.http.post<any>(this.serverUrl+"/forgotpassword",this.EmailTry,{
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      })
    }).pipe(
      tap(data => {JSON.stringify(data);
        console.log("Message "+JSON.stringify(data));
        this.code=JSON.parse(JSON.stringify(data)).code;
        
      }
      ),
      catchError(this.handleError)
    );
      
    // if(thi.code!=null){
    //   this.router.navigate(['/resetpassword']);
    // }else{
    //   formData.resetForm();
    //   alert("Password reset failed.");
    // }
  }

  forgotpassworlinksent():Observable<any>{
    console.log(localStorage.getItem('token'));
    return this.http.get(this.serverUrl+"/forgotpassworlinksent").pipe(
      tap(data => console.log("Link: "+data)
      ),
      catchError(this.handleError)
    );
  }

  resetpassword(resetview:IResetpasswordview):Observable<any>{
    console.log(localStorage.getItem('token'));
    return this.http.post<any>(this.serverUrl+"/resetpassword",resetview,{
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      })
    }).pipe(
      tap(data => {JSON.stringify(data);
        console.log("Message "+JSON.stringify(data));
      }
      ),
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
