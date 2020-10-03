import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DepartmentRoutingModule } from './department-routing.module';
import { ListdepartmentComponent } from './listdepartment/listdepartment.component';
import { AdddepartmentComponent } from './adddepartment/adddepartment.component';
import { EditdepartmentComponent } from './editdepartment/editdepartment.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [ListdepartmentComponent, AdddepartmentComponent, EditdepartmentComponent],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    BrowserModule,
    DepartmentRoutingModule
  ]
})
export class DepartmentModule { }
