import { LocalStorageServiceService } from './../../services/local-storage-service.service';
import { AuthServiceService } from './../../services/auth-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
errorMessage:string;
  constructor(private authservice:AuthServiceService,private localstore:LocalStorageServiceService) { }

  ngOnInit(): void {
  }


  
  onClick(){
    this.authservice.check().subscribe(
      (error:any)=>this.errorMessage = <any> error
    );
  }
}
