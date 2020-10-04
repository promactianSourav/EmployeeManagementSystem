import { UpdateemployeeComponent } from './updateemployee/updateemployee.component';
import { EditemployeeComponent } from './editemployee/editemployee.component';
import { AddemployeeComponent } from './addemployee/addemployee.component';
import { ListemployeeComponent } from './listemployee/listemployee.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path:'employeelist',component:ListemployeeComponent},
  {path:'employeelist/addemployee',component:AddemployeeComponent},
  {path:'employeelist/editemployee/:id',component:EditemployeeComponent},
  {path:'updateemployee',component:UpdateemployeeComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
