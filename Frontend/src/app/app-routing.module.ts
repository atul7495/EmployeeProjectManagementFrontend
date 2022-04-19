import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssignEmployeeComponent } from './Employee/assign-employee/assign-employee.component';
import { CreateEmployeeComponent } from './Employee/create-employee/create-employee.component';
import { ViewEmployeeComponent } from './Employee/view-employee/view-employee.component';
import { HomeComponent } from './home/home.component';
import { CreateProjectComponent } from './Project/create-project/create-project.component';
import { RemoveEmployeeProjectComponent } from './Project/remove-employee-project/remove-employee-project.component';
import { ViewProjectComponent } from './Project/view-project/view-project.component';

const routes: Routes = [
  {path:'', redirectTo:'home',pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:'AssignEmp/:id/:name',component:AssignEmployeeComponent},
  {path:'ViewEmp/:id',component:ViewEmployeeComponent},
  {path:'ViewProj/:id',component:ViewProjectComponent},
  {path:'RemoveProj/:id/:name',component:RemoveEmployeeProjectComponent}
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
