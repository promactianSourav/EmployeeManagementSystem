import { NotificationService } from './services/notification.service';
import { AuthServiceService } from './services/auth-service.service';
import { LocalStorageServiceService } from './services/local-storage-service.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Client';
  public _hubConnection: HubConnection;
  constructor(private notificationservice:NotificationService,private authservice: AuthServiceService, private router: Router) { }

  errorMessage:string = null;

  ngOnInit(): void {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:5001/api/notification/signalServer", {
        // skipNegotiation: true,
        // transport: signalR.HttpTransportType.WebSockets
      }).configureLogging(signalR.LogLevel.Information).build();
    this._hubConnection
      .start()
      .then(() => console.log("Connection started!"))
      .catch(err => console.log('Error while establishing connection:('));

    this._hubConnection.on("displayNotification", () => {
      this.getNotification();
    });
  }


  getNotification(){
    this.notificationservice.getnotification().subscribe(
      data => { console.log("notification:");console.log(data);},
      err => {this.errorMessage = <any> err;}
    );
  }

   readNotification(id:string,target:string) {

    // $.ajax({
    //     url: "/Notification/ReadNotification",
    //     method: "GET",
    //     data: { NotificationId: id },
    //     success: function (result) {
    //         this.getNotification();
    //         $(target).fadeOut("slow");
    //     },
    //     error: function (error) {
    //         console.log(error);
    //     }
    // });
}
  // signin:boolean = localStorage.getItem('token')!=null ? true:false;
  username: string = localStorage.getItem('username');
  get signin() {
    return localStorage.getItem('token') != null ? true : false;
  }
  logout() {
    this.authservice.logout();

    this.router.navigate(['/login']);
  }

}
