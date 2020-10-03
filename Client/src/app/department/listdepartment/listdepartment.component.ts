import { IDepartment } from './../../models/IDepartment';
import { DepartService } from './../../services/depart.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listdepartment',
  templateUrl: './listdepartment.component.html',
  styleUrls: ['./listdepartment.component.css']
})
export class ListdepartmentComponent implements OnInit {

  constructor(private departservice:DepartService,private router:Router) { }

  errorMessage:string=null;
  departmentlist:IDepartment[]=[];
  newdepartment:string=null;
  departmentfull:IDepartment = {deptId:null,departmentName:null};
  ngOnInit(): void {
    this.departservice.getlist().subscribe(
      departments => {
          this.departmentlist = departments;
          console.log(this.departmentlist);
      },
      error => this.errorMessage = <any>error
    );
  }

  deletedepartment(id:string){
    this.departservice.deletedepart(id).subscribe(
      data => {this.ngOnInit();},
      error => {this.errorMessage=<any> error;}
    );
    // this.ngOnInit();
    
  }

  get adddepartment(){
    console.log(this.newdepartment);
    if(this.newdepartment !=null){
      this.departmentfull.departmentName=this.newdepartment;
      this.departservice.adddepart(this.departmentfull).subscribe(
        data => {this.ngOnInit();},
        error => {this.errorMessage=<any> error;}
      );
      this.ngOnInit();
      this.newdepartment=null;
      return this.newdepartment;
    }else{
      alert("Please enter the Department Name.")
    }
    
  }
  

}
