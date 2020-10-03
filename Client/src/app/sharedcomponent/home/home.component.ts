import { catchError } from 'rxjs/operators';
import { LocalStorageServiceService } from './../../services/local-storage-service.service';
import { AuthServiceService } from './../../services/auth-service.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
errorMessage:string =null;
  constructor(private authservice:AuthServiceService,private localstore:LocalStorageServiceService,private router:Router) { }

  ngOnInit(): void {
  }


  
  onClick(){
   
    this.authservice.check().subscribe(
      
      (error:any)=>{
        this.errorMessage = <any> error;
       
          // this.router.navigate(['/accessdenied']);
        
      }
    );
    // if(localStorage.getItem('erCode')=='403'){
    //   this.router.navigate(['/accessdenied']);
    // }
    
  }
}
