import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { HomeComponent } from 'src/app/home/home.component';
import { ProjService } from 'src/app/Service/proj_service';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css']
})
export class CreateProjectComponent implements OnInit,OnDestroy {

  @Input() proj:any;
  isAddMode: boolean = false;
  _subscription= new Subscription();
  ProjectForm: FormGroup = new FormGroup({ });
  getIdSubscription: Subscription = new Subscription;
  updateSubscription: Subscription = new Subscription;
  createSubscription: Subscription = new Subscription;
  errorMessage: any;
   
  constructor(private projservice:ProjService,private snack:MatSnackBar, private home:HomeComponent) { }

  ngOnInit(): void {
    this.ProjectForm=new FormGroup({
    pname: new FormControl('', [Validators.required]),
    pdetail: new FormControl('', [Validators.required]),
    pdate: new FormControl('', [Validators.required])
    })

    if(this.proj==0)  
      this.isAddMode=true;

      if(!this.isAddMode)
      {
       this.getIdSubscription= this.projservice.GetById(this.proj).subscribe((data)=>{
           this.ProjectForm.patchValue(data);
        },(error)=>{
          this.errorMessage=error.message;
          throw error;
        })
      }
  
    }

    back(){
    this.home.ActivateAddEditEmpComp=false;
    this.home.ActivateAddEditProjComp=false;
    this.home.showButton=true;

    }

  OnSubmit(){

    if(this.ProjectForm.invalid)
    return;
    else if(!this.isAddMode)
    {
      this.updateSubscription = 
      this.projservice.UpdateProj(this.proj,this.ProjectForm.value).subscribe(()=>{
        this.snack.open("Project Updated");

      },(error)=>{
        this.errorMessage=error.message;
        throw error;
      })
    }
    else{
      this.createSubscription =
      this.projservice.ProjCreate(this.ProjectForm.value).subscribe(()=>{
        this.snack.open("Project Addedd");
      },(error)=>{
        this.errorMessage=error.message;
        throw error;
      })
    }

    
  }

  ngOnDestroy(){
      this.getIdSubscription.unsubscribe();
      this.updateSubscription.unsubscribe();
      this.createSubscription.unsubscribe();
  }
}
