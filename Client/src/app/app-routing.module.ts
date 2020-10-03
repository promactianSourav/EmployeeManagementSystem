import { PagenotfoundComponent } from './sharedcomponent/pagenotfound/pagenotfound.component';
import { LoginComponent } from './security/login/login.component';
// import { HomeComponent } from './sharedcomponent/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './sharedcomponent/home/home.component';


const routes: Routes = [
  {path:'',redirectTo:'/home',pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:'accessdenied',component:HomeComponent},
  {path:'**',component:PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
