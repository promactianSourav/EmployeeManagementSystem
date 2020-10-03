import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EditemployeeComponent } from './editemployee/editemployee.component';
import { AddemployeeComponent } from './addemployee/addemployee.component';
import { UpdateemployeeComponent } from './updateemployee/updateemployee.component';
import { ListemployeeComponent } from './listemployee/listemployee.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [EditemployeeComponent, AddemployeeComponent, UpdateemployeeComponent, ListemployeeComponent],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    BrowserModule,
    EmployeeRoutingModule
  ]
})
export class EmployeeModule { }
