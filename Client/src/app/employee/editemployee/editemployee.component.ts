import { NotificationService } from './../../services/notification.service';
import { IEmployee } from './../../models/IEmployee';
import { EmpService } from './../../services/emp.service';
import { Component, OnInit } from '@angular/core';
import { DepartService } from 'src/app/services/depart.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IDepartment } from 'src/app/models/IDepartment';

@Component({
  selector: 'app-editemployee',
  templateUrl: './editemployee.component.html',
  styleUrls: ['./editemployee.component.css']
})
export class EditemployeeComponent implements OnInit {

  constructor(private notificationservice:NotificationService,private departservice:DepartService,private empservice:EmpService,private router:Router,private route:ActivatedRoute) { }
  departmentlist:IDepartment[]=[];
  employeelist:IEmployee[]=[];

  editedemployee:IEmployee={
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

  ngOnInit(): void {
    this.notificationservice.getnotification().subscribe(
      data => { console.log("notification:");console.log(data);},
      err => {this.errorMessage = <any> err;}
    );
    this.empservice.getlist().subscribe(
      emp => {
          this.employeelist = (emp);
          this.employeelist.forEach(val => { 
            if(val.id == this.id){
              this.editedemployee = val;
              this.editeddepartmentid = val.departmentId;
            }
        })
          console.log("editteddepartmetn"+ this.editeddepartment);
          console.log(this.departmentlist);
      },
      error => this.errorMessage = <any>error
    );

    this.departservice.getlist().subscribe(
      departments => {
          this.departmentlist = (departments);
          this.departmentlist.forEach(val => { 
            if(val.deptId == this.editeddepartmentid){
              this.editeddepartment = val.departmentName;
            }
        })
          // console.log("editteddepartmetn"+ this.editeddepartment);
          console.log("departmentofemployee")
          console.log(this.departmentlist);
      },
      error => this.errorMessage = <any>error
    );
    
  }



  errorMessage:string = null;
  id:string = this.route.snapshot.paramMap.get('id');
  editeddepartment:string = null;
  editeddepartmentid:string = null;
  get getname(){
   this.departmentlist.forEach(function(val) {
     if(val.deptId == this.id.toString()){
       this.editeddepartment = val.departmentName;
     }
     
    });

    return this.editeddepartment;
  }

  editfulldepart:IDepartment = {deptId:null,departmentName:null};
  editemployee(){
    // this.getname();
    console.log("Hello : "+this.editedemployee);
    // if(this.editeddepartment !=null){
    //   this.editfulldepart.deptId = this.id;
    //   this.editfulldepart.departmentName = this.editeddepartment;
      this.empservice.editemployee(this.editedemployee).subscribe(
        data => {this.ngOnInit();},
        error => {this.errorMessage=<any> error;}
      );
      this.router.navigate(['/employeelist']);
    // }else{
    //   alert("Please enter the Department Name.");
    // }
    
  }
  getNotification(){
    console.log("notification:");
    this.notificationservice.getnotification().subscribe(
      data => { console.log("notification:");console.log(data);},
      err => {this.errorMessage = <any> err;}
    );
  }
}
