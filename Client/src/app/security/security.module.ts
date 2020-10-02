import { SecurityRoutingModule } from './security-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import { ForgotpasswordlinksentComponent } from './forgotpasswordlinksent/forgotpasswordlinksent.component';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { ResetpasswordconfirmComponent } from './resetpasswordconfirm/resetpasswordconfirm.component';




@NgModule({
  declarations: [LoginComponent, RegisterComponent, ForgotpasswordComponent, ForgotpasswordlinksentComponent, ResetpasswordComponent, ResetpasswordconfirmComponent],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    BrowserModule,
    SecurityRoutingModule
  
    
    
  ]
})
export class SecurityModule { }
