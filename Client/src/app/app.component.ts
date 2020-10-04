import { AuthServiceService } from './services/auth-service.service';
import { LocalStorageServiceService } from './services/local-storage-service.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';
  constructor(private authservice:AuthServiceService,private router:Router){}
  // signin:boolean = localStorage.getItem('token')!=null ? true:false;
  username:string = localStorage.getItem('username');
  get signin(){
    return localStorage.getItem('token')!=null ? true:false;
  }
  logout(){
    this.authservice.logout();
   
    this.router.navigate(['/login']);
  }

}
