import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({
      'Context-Type': 'application/x-www-form-urlencoded',
    })
  }

  @Injectable({
    providedIn: 'root'
  })

  export class ProjectAssignService {
   readonly readURL= "https://localhost:44367/api";
   header: HttpHeaders | { [header: string]: string | string[]; } | undefined;

    constructor(private https:HttpClient){ }
    //api for getting all list of project assigned to employee 
    GetAssignProject(id:number):Observable<any[]>{
        return this.https.get<any>(this.readURL+'/ProjectAssign/'+id,httpOptions);
      }

      //api for getting list of assigned employee on project
    GetAssignEmp(id:number):Observable<any[]>{
        return this.https.patch<any>(this.readURL+'/ProjectAssign/'+id,httpOptions);
    }

    //api for removing assigned employee from project
    RemoveAssignEmp(id:number,val:any[])
    {
        return this.https.post(this.readURL+'/ProjectAssign/'+id,val,httpOptions);
    }

}