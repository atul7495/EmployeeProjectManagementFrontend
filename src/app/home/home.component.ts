
import { ChangeDetectorRef, Component, OnInit,ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmpService } from '../Service/emp_service'
import { ProjService } from '../Service/proj_service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection:ChangeDetectionStrategy.OnPush
})

export class HomeComponent implements OnInit,OnDestroy {  
  EmpList: any[] = [];
  ActivateAddEditEmpComp: boolean=false;
  ActivateAddEditProjComp:boolean=false;
  ShowEmpTable:boolean=false;
  ShowProjTable:boolean=false;
  NoEmpData:boolean=false;
  NoProjData:boolean=false;
  showButton:boolean=false;
  emp:number | undefined;
  proj:number|undefined;
 Viewemp:number|undefined;
  ProjList: any[] = [];
  displayedEmpColumns: string[] = ['empId', 'ename', 'eage','esal','edit','view','del','assign'];
  displayedProjColumns: string[] = ['projId', 'pname', 'pdetail','pdate','edit','view','del','removeProj'];
  displayData: string="No Data to display";
  delEmpSubcription: Subscription = new Subscription;
  delProjSubcription: Subscription = new Subscription;
  projListSubcription: Subscription = new Subscription;
  empListSubcription: Subscription = new Subscription;
  ActivateViewEmpComp: boolean=false;

  constructor(public empservice :EmpService,private cd : ChangeDetectorRef,
    private snack:MatSnackBar,private projservice:ProjService,private route:Router) { }

  ngOnInit(): void {
    this.showButton=true;
  }

  main() {
    this.ActivateAddEditEmpComp=false;
    this.showButton=true;
    this.ActivateAddEditProjComp=false;
    this.ShowEmpTable=false;
    this.ShowProjTable=false;
    this.ActivateViewEmpComp=false;

  }
  
  showEmpTable(){
    this.EmployeeList();
   this.ShowEmpTable=true;
   this.ShowProjTable=false;
   this.ActivateAddEditProjComp=false;
  }

  showProjTable(){
    this.ProjectList();  
  this.ShowProjTable=true;
  this.ShowEmpTable=false;
  this.ActivateAddEditEmpComp=false;
  }

  createEmp() {
    this.emp=0;
    this.ActivateAddEditProjComp=false;
  this.ActivateAddEditEmpComp=true;
  this.showButton=false;
  this.ShowProjTable=false;
  
  }
     
  AssignProj(id:number,name:string){
    this.route.navigate(['AssignEmp',id,name]);
  }
  
  RemoveProj(id:number,name:string){
   this.route.navigate(['RemoveProj',id,name])
  }

  createProj(){
    this.showButton=false;
    this.proj=0;
    this.ActivateAddEditEmpComp=false;
   this.ActivateAddEditProjComp=true;
   this.ShowEmpTable=false;
  }

  
  EmployeeList(){
    this.empListSubcription= this.empservice.ListEmp().subscribe((data)=>{
      if(data.length==0)
      {
        this.NoEmpData=true;
      }
      this.EmpList=data;
      this.cd.markForCheck();
      this.snack.open("Employee List Updated",'Close',{
        panelClass: ["snack-style"]
      })
    })
  }

  ProjectList(){
    this.projListSubcription=this.projservice.ListProj().subscribe((data)=>{
      if(data.length==0)
      {
        this.NoProjData=true;
      }
      this.ProjList=data;
      this.cd.markForCheck();
      this.snack.open("Project List Updated",'Close')
    })
  }

  delProjRecord(id:number)
  {
    this.delProjSubcription= this.projservice.DeleteProj(id).subscribe((data:any)=>{
      this.cd.markForCheck();
      console.log("Success");
      this.snack.open("Project Deleted",'Close');
      this.ProjectList();
     })
    
  }

  editProjRecord(id:number){
    this.proj=id;
    this.showButton=false;
    this.ActivateAddEditProjComp=true;
  }

  viewProjRecord(id:number){
    this.route.navigate(['ViewProj',id]);
  }
  delEmpRecord(id:number)
  {
  this.delEmpSubcription= this.empservice.DeleteEmp(id).subscribe((data:any)=>{
   this.cd.markForCheck();
   console.log("Success");
   this.snack.open("Employee Deleted",'Close');
  this.EmployeeList();
  })
  }

  editEmpRecord(id: any): void{
  this.emp=id;
  this.showButton=false;
  this.ActivateAddEditEmpComp=true;
}

viewEmpRecord(id:any):void{
  this.route.navigate(['ViewEmp',id]);
}
 
ngOnDestroy(): void{
  //unsubcribing the subscription for preventing memory leaks
  this.delEmpSubcription.unsubscribe();
  this.delProjSubcription.unsubscribe();
  this.empListSubcription.unsubscribe();
  this.projListSubcription.unsubscribe();
}
  
}
