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


export class ProjService{

    readonly readURL= "https://localhost:44367/api";
    header: HttpHeaders | { [header: string]: string | string[]; } | undefined;
 
     constructor(private https:HttpClient){ }

     //api for creating new project
     ProjCreate(val:any){
        return this.https.post(this.readURL+'/Project',val,httpOptions)
    }
      //api for listing all project
    ListProj():Observable<any[]>{
        return this.https.get<any>(this.readURL+'/ProjectList',httpOptions);
      }
 
      //api for deleting single project with reference to id
      DeleteProj(id:number){
        return this.https.delete(this.readURL+'/Project/'+id,httpOptions);
      }

      //api for getting single project with reference to id
      GetById(id:number):Observable<any[]>{
        return this.https.get<any>(this.readURL+'/Project/'+id,httpOptions);
      }

      //api for updating project with reference to id
      UpdateProj(id:number,val:any){
        return this.https.put(this.readURL+'/Project/'+id,val,httpOptions);
      }

}