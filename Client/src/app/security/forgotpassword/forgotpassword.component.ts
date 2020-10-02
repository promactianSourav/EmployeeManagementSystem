import { AuthServiceService } from './../../services/auth-service.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {

  errorMessage:string;
  constructor(private authservice:AuthServiceService,private router:Router) { }
  email:string=null;
  ngOnInit(): void {
  }
  onSubmit(formData:NgForm){
    this.authservice.forgotpassword(this.email).subscribe(
      (error:any)=>this.errorMessage = <any> error
    );
    console.log(localStorage.getItem('token'));
    
    if(this.authservice.code!=null){
      this.router.navigate(['/resetpassword']);
    }else{
      formData.resetForm();
      alert("Password reset failed.");
    }
   
  }

}
