import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {tap } from 'rxjs/operators';
import { Observable } from 'rxjs';


const httpOptions = {
    headers: new HttpHeaders({
      'Context-Type': 'application/x-www-form-urlencoded',
    })
  }

  @Injectable({
    providedIn: 'root'
  })

  export class EmpService {
   readonly readURL= "https://localhost:44367/api";
   header: HttpHeaders | { [header: string]: string | string[]; } | undefined;

    constructor(private https:HttpClient){ }
     //create api for employee
    EmpCreate(val:any){
        return this.https.post(this.readURL+'/Employee',val,httpOptions)
    }

    //api for list all employee
    ListEmp():Observable<any[]>{
      const headers = { 'content-type': 'application/json'}  
   return this.https.get<any>(this.readURL+'/EmployeeList',{'headers':headers}).pipe(tap(data=>{}) );
    }

    //api for delete employee
    DeleteEmp(id:number){
      return this.https.delete(this.readURL+'/Employee/'+id,httpOptions);
    }

    //api for get single employee by id
    GetById(id:number):Observable<any[]>{
      return this.https.get<any>(this.readURL+'/Employee/'+id,httpOptions);
    }
    //update api for employee
    UpdateEmp(id:number,val:any){
      return this.https.put(this.readURL+'/Employee/'+id,val,httpOptions);
    }
     //api for assigning project to employee
    AssignProject(id:number,val:any[]){
    return this.https.post(this.readURL+'/Employee/'+id,val,httpOptions)
    }

  }


