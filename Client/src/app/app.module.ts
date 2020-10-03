import { EmployeeModule } from './employee/employee.module';
import { EmployeeRoutingModule } from './employee/employee-routing.module';
import { SecurityRoutingModule } from './security/security-routing.module';
import { SecurityModule } from './security/security.module';
import { UniversalAppInterceptorService } from './services/universal-app-interceptor.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './sharedcomponent/home/home.component';
import { HeaderComponent } from './sharedcomponent/header/header.component';
import { FooterComponent } from './sharedcomponent/footer/footer.component';
import { PagenotfoundComponent } from './sharedcomponent/pagenotfound/pagenotfound.component';
import { DepartmentModule } from './department/department.module';
import { DepartmentRoutingModule } from './department/department-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    PagenotfoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    SecurityRoutingModule,
    SecurityModule,
    DepartmentRoutingModule,
    DepartmentModule,
    EmployeeRoutingModule,
    EmployeeModule,
    AppRoutingModule
   
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: UniversalAppInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
