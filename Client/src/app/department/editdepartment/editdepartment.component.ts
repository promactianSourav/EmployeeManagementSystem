import { IDepartment } from './../../models/IDepartment';
import { DepartService } from './../../services/depart.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';


@Component({
  selector: 'app-editdepartment',
  templateUrl: './editdepartment.component.html',
  styleUrls: ['./editdepartment.component.css']
})
export class EditdepartmentComponent implements OnInit {

  constructor(private departservice:DepartService,private router:Router,private route:ActivatedRoute) { }
  departmentlist:IDepartment[]=[];
  ngOnInit(): void {
    this.departservice.getlist().subscribe(
      departments => {
          this.departmentlist = (departments);
          this.departmentlist.forEach(val => { 
            if(val.deptId == this.id){
              this.editeddepartment = val.departmentName;
            }
        })
          console.log("editteddepartmetn"+ this.editeddepartment);
          console.log(this.departmentlist);
      },
      error => this.errorMessage = <any>error
    );
    
  }
  errorMessage:string = null;
  id:string = this.route.snapshot.paramMap.get('name');
  editeddepartment:string = null;
  // get getname(){
  //  this.departmentlist.forEach(function(val) {
  //    if(val.deptId == this.id.toString()){
  //      this.editeddepartment = val.departmentName;
  //    }
     
  //   });

  //   return this.editeddepartment;
  // }

  editfulldepart:IDepartment = {deptId:null,departmentName:null};
  editdepartment(){
    // this.getname();
    console.log("Hello : "+this.editeddepartment);
    if(this.editeddepartment !=null){
      this.editfulldepart.deptId = this.id;
      this.editfulldepart.departmentName = this.editeddepartment;
      this.departservice.editdepart(this.id,this.editfulldepart).subscribe(
        data => {this.ngOnInit();},
        error => {this.errorMessage=<any> error;}
      );
      this.router.navigate(['/departmentlist']);
    }else{
      alert("Please enter the Department Name.");
    }
    
  }
}
