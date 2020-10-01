import { ILoginview } from './../../models/ILoginview';
import { AuthServiceService } from './../../services/auth-service.service';
import { Component, OnInit } from '@angular/core';
import { NgForm,FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authservice:AuthServiceService,private router:Router) { }

  ngOnInit(): void {
  }
  errorMessage:string;
  username:string=null;
  password:string=null;
  readme:boolean=false;
  loginview:ILoginview = {username:this.username,password:this.password,readme:this.readme};
  onSubmit(formData:NgForm){
    this.loginview.username = this.username;
    this.loginview.password = this.password;
    this.loginview.readme = this.readme;
    console.log(this.loginview);
    this.authservice.login(this.loginview).subscribe(
      (error:any)=>this.errorMessage = <any> error
    );
    console.log(localStorage.getItem('token'));
    formData.resetForm();
    this.router.navigate(['/home']);
  }
}
