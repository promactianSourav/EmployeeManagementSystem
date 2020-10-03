import { EditdepartmentComponent } from './editdepartment/editdepartment.component';
import { AdddepartmentComponent } from './adddepartment/adddepartment.component';
import { ListdepartmentComponent } from './listdepartment/listdepartment.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path:'departmentlist',component:ListdepartmentComponent},
  {path:'adddepartment',component:AdddepartmentComponent},
  {path:'departmentlist/editdepartment/:name',component:EditdepartmentComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartmentRoutingModule { }
