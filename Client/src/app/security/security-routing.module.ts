import { ResetpasswordconfirmComponent } from './resetpasswordconfirm/resetpasswordconfirm.component';
import { ResetpasswordComponent } from './resetpassword/resetpassword.component';
import { ForgotpasswordlinksentComponent } from './forgotpasswordlinksent/forgotpasswordlinksent.component';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'forgotpassword',component:ForgotpasswordComponent},
  {path:'forgotpasswordlinksent',component:ForgotpasswordlinksentComponent},
  {path:'resetpassword',component:ResetpasswordComponent},
  {path:'resetpasswordconfirm',component:ResetpasswordconfirmComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityRoutingModule { }
