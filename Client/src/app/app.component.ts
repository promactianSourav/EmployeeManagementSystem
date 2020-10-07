import { NotificationService } from './services/notification.service';
import { AuthServiceService } from './services/auth-service.service';
import { LocalStorageServiceService } from './services/local-storage-service.service';
import { Component, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { NotifierService } from 'angular-notifier';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Client';
  public _hubConnection: HubConnection;
  constructor(private notifierservice:NotifierService,private notificationservice:NotificationService,private authservice: AuthServiceService, private router: Router) { }
 

  errorMessage:string = null;

  ngOnInit(): void {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/signalServer'
      // , {
      //   skipNegotiation: true,
      //   transport: signalR.HttpTransportType.WebSockets
      // }
      ).configureLogging(signalR.LogLevel.Information).build();

      this._hubConnection.on("displayNotification", () => {
        // console.log("notificationOn");
        this.getNotification();
      });

    this._hubConnection
      .start()
      .then(() => {console.log("Connection started!");this.getNotification();})
      .catch(err => console.log('Error while establishing connection:('));

      this.getNotification();
      this.notificationservice.getnotification().subscribe(
        data => { this.count =(data.count);
          // console.log("notification:");console.log(data);console.log("userid"+localStorage.getItem('token'));
        },
        err => {this.errorMessage = <any> err;}
      );
  }

notifications:any[]=[];
  notificationlist(){
    this.getNotification();
    this.getset();
    // document.getElementById('notificationCount').innerHTML('<div></div>');
    if(this.count>0 || this.ntl==true){
      if(this.ntl==true){
        this.ntl=false;
      }else{
        this.ntl = true;
      }
     
    }

  }
  ntl:boolean = false;
count:number = 0;
  getNotification(){
    // console.log("notification:");
    this.notificationservice.getnotification().subscribe(
      data => { 
        this.count =(data.count);
        this.notifications = data.notificationUser;
        // console.log("notificationslist");
        // console.log(this.notifications);
        // console.log("notification:");
        // console.log(data);console.log("userid"+localStorage.getItem('token'));
      },
      err => {this.errorMessage = <any> err;}
    );
  }

  readNotification(id:string) {
    this.notificationservice.readnotification(id).subscribe(
      data => { 
        // console.log(data);
      },
      err => {this.errorMessage = <any> err;}
    );
    this.getNotification();
    this.ngOnInit();
  }

  
  @ViewChild ("cn",{static:true}) cntm;

 
  i:number = 0;
  ch:boolean = false;

  getid(i:string){
    this.readNotification(i);
    this.ngOnInit();
    // console.log("idnoti: "+i);
  }

  getset(){
  
    if(this.ch==false){
      this.notifications.forEach(element => {
        // this.i=this.i+1;
        this.notifierservice.show({
          type:"success",
          message:element.text,
          id: element.id,
          template:this.cntm
        });
      });
      
      this.ch=true;
    }else{
      this.notifierservice.hideAll();
      this.ch=false;
    }
   
    
  }



  // signin:boolean = localStorage.getItem('token')!=null ? true:false;
  username: string = localStorage.getItem('username');

  //for changing the navbar options after logged in
  get signin() {
    this.username = localStorage.getItem('username');
    return localStorage.getItem('token') != null ? true : false;
  }
 
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('userid');
    this.authservice.logout();
    localStorage.clear();
    this.notifierservice.hideAll();
    this.ch=false;

    this.router.navigate(['/login']);
  }

}
