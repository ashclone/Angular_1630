import { EmployeeComponent } from './employee/employee.component';
import { ViewemployeeComponent } from './employee/viewemployee/viewemployee/viewemployee.component';
import { ViewstudentComponent } from './students/ViewStudent/viewstudent/viewstudent.component';
import { StudentsComponent } from './students/students.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: StudentsComponent },
  { path: 'students', component: StudentsComponent },
  { path: 'students/:id', component: ViewstudentComponent },
  { path: 'students/add', component: ViewstudentComponent },
  { path: 'employees', component: EmployeeComponent },
  { path: 'employees/:id', component: ViewemployeeComponent },
  { path: 'employees/add', component: ViewemployeeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
