import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IDepartment } from 'src/app/models/IDepartment';
import { IEmployee } from 'src/app/models/IEmployee';
import { DepartService } from 'src/app/services/depart.service';
import { EmpService } from 'src/app/services/emp.service';

@Component({
  selector: 'app-updateemployee',
  templateUrl: './updateemployee.component.html',
  styleUrls: ['./updateemployee.component.css']
})
export class UpdateemployeeComponent implements OnInit {

  constructor(private departservice:DepartService,private empservice:EmpService,private router:Router,private route:ActivatedRoute) { }
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
  // id:string = this.route.snapshot.paramMap.get('id');
  id:string = localStorage.getItem('userid');
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
  updateemployee(){
    // this.getname();
    console.log("Hello : "+this.editedemployee);
    // if(this.editeddepartment !=null){
    //   this.editfulldepart.deptId = this.id;
    //   this.editfulldepart.departmentName = this.editeddepartment;
      this.empservice.updateemployee(this.editedemployee).subscribe(
        data => {this.ngOnInit();},
        error => {this.errorMessage=<any> error;}
      );
      this.router.navigate(['/employeelist']);
    // }else{
    //   alert("Please enter the Department Name.");
    // }
    
  }

}
