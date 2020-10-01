import { HttpClient, HttpClientModule ,HttpErrorResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable ,throwError,pipe} from 'rxjs';
import {catchError,tap,map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {


  private serverUrl = "https://localhost:5001/api/security";

  constructor(private http:HttpClient) { }

  login(username:string,password:string): Observable<any>{
    return this.http.post<any>(this.serverUrl).pipe(
      tap(data => JSON.stringify(data)),
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
