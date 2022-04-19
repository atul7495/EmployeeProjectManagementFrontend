import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmpService } from 'src/app/Service/emp_service';
import { ProjectAssignService } from 'src/app/Service/proj_assign_service';

@Component({
  selector: 'app-view-employee',
  templateUrl: './view-employee.component.html',
  styleUrls: ['./view-employee.component.css']
})
export class ViewEmployeeComponent implements OnInit,OnDestroy {
  getIdSubs: Subscription = new Subscription;
  @Input() Viewemp:any;
  Empdata:any=[];
  routeSub: Subscription = new Subscription;
  
  empId: any;
  assignProjSubs: Subscription = new Subscription;
  projectAssign:any;
  constructor(private assignprojservice:ProjectAssignService, private empservice:EmpService,
    private route:ActivatedRoute) { }
  
  
  ngOnDestroy(): void {
    this.getIdSubs.unsubscribe();
    this.routeSub.unsubscribe();
    this.assignProjSubs.unsubscribe();
  }

  ngOnInit(): void {
  
    this.routeSub = this.route.params.subscribe(params => {
      this.empId= params['id'] //get the value of id
      });

    this.getIdSubs= this.empservice.GetById(this.empId).subscribe((data)=>{
       this.Empdata.push(data); //filling data in the array
    });
    
    this.assignProjSubs=this.assignprojservice.GetAssignProject(this.empId).subscribe((data)=>{
      if(data.length==0)
        this.projectAssign="No project assigned yet !";
      else{
        this.projectAssign=data;
      }
    })
  }

 
}
