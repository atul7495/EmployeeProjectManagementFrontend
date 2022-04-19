import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';
import { ProjectAssignService } from 'src/app/Service/proj_assign_service';

@Component({
  selector: 'app-remove-employee-project',
  templateUrl: './remove-employee-project.component.html',
  styleUrls: ['./remove-employee-project.component.css']
})
export class RemoveEmployeeProjectComponent implements OnInit,OnDestroy {
  routeSub: Subscription = new Subscription;
  projId: any;
  empList: any[] = [];
  selectedItemsList: any[]=[];
  checkedIDs: any[] = [];
  name: any;
  ProjAlertMessaage: string = "No employee assigned to this project yet";
  GetAssignEmpSub: Subscription = new Subscription;
  removeAssignEmpSubs: Subscription = new Subscription;
  errorMessage: any;

  constructor(private projassign:ProjectAssignService, private route:ActivatedRoute, private snack:MatSnackBar) { }
  

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.projId= params['id']; //get the value of id
      this.name=params['name'];
      });
    this.GetAssignEmpSub = this.projassign.GetAssignEmp(this.projId).subscribe((data)=>{
     this.empList=data;
    
    },(error)=>{
      this.errorMessage=error.message;
      
      throw error;
    })
    this.fetchSelectedItems();
    this.fetchCheckedIDs();
  }
  
  changeSelection() {
    this.fetchSelectedItems()
  }

  fetchSelectedItems() {
    //filtering the cheked item from checkbox
    this.selectedItemsList = this.empList.filter((value) => {
      return value.isChecked 
    });
  }

  fetchCheckedIDs() {
    //pushing the checked id in the check id array
    this.checkedIDs = []
    this.empList.forEach((value) => {
      if (value.isChecked) {
        this.checkedIDs.push(value.id);
      }
    });
  }

  OnSubmit(){
  
   this.removeAssignEmpSubs=   this.projassign.RemoveAssignEmp(this.projId,this.selectedItemsList).subscribe(()=>{
        this.snack.open(this.name+"removed from this project");
        this.ngOnInit();
      },(error)=>{
        this.errorMessage=error.message;
        
        throw error;
      })
  }
  
  ngOnDestroy(): void {
    this.GetAssignEmpSub.unsubscribe();
    this.removeAssignEmpSubs.unsubscribe();
    this.routeSub.unsubscribe();
  }
}
