import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmpService } from 'src/app/Service/emp_service';
import { ProjService } from 'src/app/Service/proj_service';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-assign-employee',
  templateUrl: './assign-employee.component.html',
  styleUrls: ['./assign-employee.component.css']
})

export class AssignEmployeeComponent implements OnInit {

  assignProject: FormGroup = new FormGroup({});
  projList: any[] = [];
  selectedItemsList :any[]= [];
  checkedIDs :any[]= [];
  assign :any;
  _Subscription: Subscription = new Subscription();
  routeSub: Subscription = new Subscription();
  projSub: Subscription = new Subscription;
  name: any;


  constructor(private fb:FormBuilder, private projservice:ProjService,
    private empservice:EmpService,private route: ActivatedRoute,
    private snack:MatSnackBar) {
   }

   ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
    this.assign= params['id'] //get the value of id
    this.name=params['name']
    });

    this.projSub= this.projservice.ListProj().subscribe((data)=>{
      this.projList=data;  
    })

    this.fetchSelectedItems();
    this.fetchCheckedIDs();
  }

  
  changeSelection() {
    this.fetchSelectedItems()
  }

  fetchSelectedItems() {
    this.selectedItemsList = this.projList.filter((value) => {
      return value.isChecked
    });
  }

  fetchCheckedIDs() {
    this.checkedIDs = []
    this.projList.forEach((value) => {
      if (value.isChecked) {
        console.log(value.id);
        this.checkedIDs.push(value.id);
      }
    });
  }

  
 OnSubmit(){
   console.log("id "+this.assign);
 this._Subscription=  this.empservice.AssignProject(this.assign,this.selectedItemsList).subscribe(()=>{
     this.snack.open("Project assigned to "+this.name);
   })
 }

 ngOnDestroy(): void{
  this._Subscription.unsubscribe();
  this.routeSub.unsubscribe();
  this.projSub.unsubscribe();
}

}
