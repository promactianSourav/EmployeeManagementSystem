import { EmpService } from './../../services/emp.service';
import { IEmployee } from './../../models/IEmployee';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IDepartment } from 'src/app/models/IDepartment';
import { DepartService } from 'src/app/services/depart.service';

@Component({
  selector: 'app-listemployee',
  templateUrl: './listemployee.component.html',
  styleUrls: ['./listemployee.component.css']
})
export class ListemployeeComponent implements OnInit {

  constructor(private departservice:DepartService,private empservice:EmpService,private router:Router) { }

  errorMessage:string=null;
  departmentlist:IDepartment[]=[];
  employeelist:IEmployee[]=[];

  newdepartment:string=null;
  departmentfull:IDepartment = {deptId:null,departmentName:null};
  ngOnInit(): void {
    this.departservice.getlist().subscribe(
      departments => {
          this.departmentlist = departments;
          if(this.departmentlist.length){
            this.check = false;
          }else{
            this.check = true;
          }
          console.log(this.departmentlist);
      },
      error => this.errorMessage = <any>error
    );
    this.empservice.getlist().subscribe(
      employees => {
          this.employeelist = employees;
          this.employeelist.forEach(emp =>{
            if(emp.id==localStorage.getItem('userid')){
              this.loggedinemp = emp;
            }
          })
          console.log(this.employeelist);
      },
      error => this.errorMessage = <any>error
    );
  }
  loggedinemp:IEmployee = {
    id:null,
    userName:null,
    email:null,
    password:null,
    confirmPassword:null,
    name:null,
    surname:null,
    address:null,
    qualification:null,
    contactNumber:null,
    departmentId:null
  };
  deleteemployee(id:string){
    console.log("id:  "+id);
    this.empservice.deleteemployee(id).subscribe(
      data => {this.ngOnInit();},
      error => {this.errorMessage=<any> error;}
    );
    // this.ngOnInit();
    
  }
  check:boolean = true;
  get checkdep(){
    // if(this.departmentlist.length == 0){
    //   return false;
    // }else{
    //   return true;
    // }
    return this.check;
  }
  free:boolean = true;
  get freehradmin(){
    if(this.loggedinemp.userName == "HR" || this.loggedinemp.userName=="Admin"){
      this.free = true;
    }else{
      this.free =false;
    }
    return this.free;
  }

  // get adddepartment(){
  //   console.log(this.newdepartment);
  //   if(this.newdepartment !=null){
  //     this.departmentfull.departmentName=this.newdepartment;
  //     this.departservice.adddepart(this.departmentfull).subscribe(
  //       data => {this.ngOnInit();},
  //       error => {this.errorMessage=<any> error;}
  //     );
  //     this.ngOnInit();
  //     this.newdepartment=null;
  //     return this.newdepartment;
  //   }else{
  //     alert("Please enter the Department Name.")
  //   }
    
  // }

}
