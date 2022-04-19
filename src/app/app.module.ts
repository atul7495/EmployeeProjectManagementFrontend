import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from '@angular/common/http'
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import {MatButtonModule} from '@angular/material/button';
import { CreateEmployeeComponent } from './Employee/create-employee/create-employee.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { CreateProjectComponent } from './Project/create-project/create-project.component';
import { HomeComponent } from './home/home.component';
import {MatTableModule} from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS} from'@angular/material/snack-bar';
import { AssignEmployeeComponent } from './Employee/assign-employee/assign-employee.component';
import { ViewEmployeeComponent } from './Employee/view-employee/view-employee.component';
import { ViewProjectComponent } from './Project/view-project/view-project.component';
import { RemoveEmployeeProjectComponent } from './Project/remove-employee-project/remove-employee-project.component'



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CreateEmployeeComponent,
    CreateProjectComponent,
    HomeComponent,
    AssignEmployeeComponent,
    ViewEmployeeComponent,
    ViewProjectComponent,
    RemoveEmployeeProjectComponent,
],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    MatTableModule,
    MatSnackBarModule,
    MatCheckboxModule
    
  ],
  providers: [{provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: 2500}}],
  bootstrap: [AppComponent]
})
export class AppModule { }
