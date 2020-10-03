import { IResetpasswordview } from './../../models/IResetpasswordview';
import { AuthServiceService } from './../../services/auth-service.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.css']
})
export class ResetpasswordComponent implements OnInit {

  errorMessage:string;
  resetpassword:IResetpasswordview={code:null,email:null,password:null,confirmpassword:null};
  constructor(private authservice:AuthServiceService,private router:Router) { }

  ngOnInit(): void {
  }
  code:string = this.authservice.code;
  email:string=null;
  password:string=null;
  confirmpassword:string=null;
  onSubmit(formData:NgForm){
    this.resetpassword.code = this.code;
    this.resetpassword.email = this.email;
    this.resetpassword.password = this.password;
    this.resetpassword.confirmpassword = this.confirmpassword;

    console.log(this.resetpassword);
    this.authservice.resetpassword(this.resetpassword).subscribe(
      (error:any)=>this.errorMessage = <any> error
    );
    console.log(localStorage.getItem('token'));
    
    if(this.authservice.code!=null){
      this.router.navigate(['/resetpasswordconfirm']);
    }else{
      formData.resetForm();
      alert("Password reset failed.");
      this.router.navigate(['/forgotpassword']);
    }
   
  }

}
