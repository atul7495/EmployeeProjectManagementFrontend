import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormGroup,FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { EmpService } from 'src/app/Service/emp_service';
import{  HomeComponent } from 'src/app/home/home.component'
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit,OnDestroy {
  EmployeeForm: FormGroup = new FormGroup({});
  errorMessage: any;
  ActivateHome:boolean=false;
  isAddMode: boolean = false;
  id: any;
  getIdSubs: Subscription = new Subscription;
  updateSubs: Subscription = new Subscription;
  createSubs: Subscription = new Subscription;

  constructor(private empservice:EmpService,private snack:MatSnackBar,
    private router:Router,private route:ActivatedRoute, private home:HomeComponent) { }

  ngOnDestroy(): void {
   this.updateSubs.unsubscribe();
   this.getIdSubs.unsubscribe();
   this.createSubs.unsubscribe();
  }
   
  @Input() emp:any;
  ngOnInit(): void {

    this.EmployeeForm = new FormGroup({
    ename: new FormControl('', [Validators.required]),
    eage: new FormControl('', [Validators.required]),
    esal: new FormControl('', [Validators.required])
    })
   
    
    if(this.emp==0)
      this.isAddMode=true;
    

    if(!this.isAddMode)
    {
     this.getIdSubs= this.empservice.GetById(this.emp).subscribe((data)=>{
        this.EmployeeForm.patchValue(data);
      })
    }
  }

  back(){
    this.home.ActivateAddEditEmpComp=false;
    this.home.ActivateAddEditProjComp=false;
    this.home.showButton=true;
    this.ActivateHome=true;
  }

  OnSubmit(){
    if(this.EmployeeForm.invalid){
      return;
    }
    else if(!this.isAddMode){
    this.updateSubs = this.empservice.UpdateEmp(this.emp,this.EmployeeForm.value).subscribe(()=>{

        this.EmployeeForm.controls['ename'].disable();
        this.EmployeeForm.controls['eage'].disable();
        this.EmployeeForm.controls['esal'].disable();
        this.snack.open("Employee Data Updated");
      
      },(error)=>{
        this.errorMessage=error.message;
        throw error;
      })

    }
    else{
      this.isAddMode=true;
      console.log(this.EmployeeForm.value);
      this.createSubs=this.empservice.EmpCreate(this.EmployeeForm.value).subscribe((data)=>{
        console.log("Successful");
        this.snack.open("Employee Added");

      },(error)=>{
        this.errorMessage=error.message;
        
        throw error;
      }
      )
    }
  }
}
