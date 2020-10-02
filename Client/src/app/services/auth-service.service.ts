import { IResetpasswordview } from './../models/IResetpasswordview';
import { ILoginview } from './../models/ILoginview';
import { LocalStorageServiceService } from './local-storage-service.service';
import { JWTTokenServiceService } from './jwttoken-service.service';
import { HttpClient, HttpClientModule ,HttpErrorResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable ,throwError,pipe} from 'rxjs';
import {catchError,tap,map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {


  private serverUrl = "https://localhost:5001/api/security";

  constructor(private http:HttpClient,private jwttoken:JWTTokenServiceService,private localstore:LocalStorageServiceService) { }
  user:string=null;
  login(form:ILoginview): Observable<any>{
    return this.http.post<any>(this.serverUrl+"/login",form).pipe(
      tap(data => {JSON.stringify(data);
        console.log(data);
        this.user = data.username;
          this.localstore.set('token',data.token);
        this.localstore.set('user',data.username);}
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

  code:string=null;
  forgotpassword(email:string):Observable<any>{
    console.log(localStorage.getItem('token'));
    return this.http.post<any>(this.serverUrl+"/forgotpassword",email).pipe(
      tap(data => {JSON.stringify(data);
        console.log("Message "+JSON.stringify(data));
        this.code=data.code;
      }
      ),
      catchError(this.handleError)
    );
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
    return this.http.post<any>(this.serverUrl+"/resetpassword",resetview).pipe(
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
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
