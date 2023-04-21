import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  FormBuilder,
  FormControlName,
  Validators,
} from '@angular/forms';
import { employee } from 'src/app/infrastructure/employee.interface';
import { EmployeeService } from './../../../_services/employee.service';
import { Hobbies } from './../../../infrastructure/hobbies.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-viewemployee',
  templateUrl: './viewemployee.component.html',
  styleUrls: ['./viewemployee.component.scss'],
})
export class ViewemployeeComponent implements OnInit {
  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router,
    private snackbar: MatSnackBar,
    private employeeFormBuilder: FormBuilder
  ) {}
  ngOnInit(): void {
    this.employeeService.getAllHobbies().subscribe(
      (response) => {
        this.allHobbies = response;
        console.log(this.allHobbies);
      },
      (error) => {
        //alert('Error in calling services ' + error);
      }
    );
    this.route.paramMap.subscribe((x) => {
      this.EditId = x.get('id');
      console.log(this.EditId);
    });
  }
  title = 'New Employee';
  EditId: string | null | undefined;
  allHobbies: Hobbies[] = [];
  EmployeeContainer: employee = {
    id: 0,
    name: '',
    address: '',
    age: 0,
    email: '',
    salary: 0,
    bio: '',
    hob: [],
  };
  employeeform = this.employeeFormBuilder.group({
    id: 0,
    name: '',
    address: '',
    age: 0,
    email: '',
    salary: 0,
    bio: '',
    hob: [''],
  });
  employee = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
    address: new FormControl(''),
    age: new FormControl(0),
    email: new FormControl(''),
    salary: new FormControl(0),
    bio: new FormControl(''),
    hob: new FormControl(['']),
  });
  saveClick(): void {
    console.log(this.employee.value);

    this.EmployeeContainer = this.employee.value as employee;
    this.employeeService.addEmployee(this.EmployeeContainer).subscribe(
      (Response) => {
        this.snackbar.open('Employee Added Successfully ', undefined, {
          duration: 2000,
        });
        console.log(Response);
        setTimeout(() => {
          this.router.navigateByUrl('employees');
        }, 2000);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
