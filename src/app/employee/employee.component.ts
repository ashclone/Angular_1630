import { Component, OnInit, SecurityContext } from '@angular/core';
import { employee } from '../infrastructure/employee.interface';
import { EmployeeService } from '../_services/employee.service';
import { MatTableDataSource } from '@angular/material/table';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
})
export class EmployeeComponent implements OnInit {
  employee: employee[] = [];
  constructor(
    private employeeService: EmployeeService,
    private sanitizer: DomSanitizer
  ) {
    //this.getAll();
  }
  ngOnInit(): void {
    //debugger;
    this.getAll();
  }
  dataSource: MatTableDataSource<employee> = new MatTableDataSource<employee>();
  displayedColumns: string[] = [
    'Name',
    'Address',
    'age',
    'Email',
    'salary',
    'bio',
    'hobby',
  ];
  sanitizeHtml(html: string) {
    return this.sanitizer.bypassSecurityTrustHtml(html);
  }
  removeTags(str: string): string | null {
    return this.sanitizer.sanitize(
      SecurityContext.HTML,
      str.replace(/<[^>]*>/g, '')
    );
  }

  getAll() {
    // debugger;
    this.employeeService.getAllEmployees().subscribe(
      (response) => {
        this.employee = response;
        this.dataSource = new MatTableDataSource<employee>(this.employee);
        console.log(response);
        console.log(this.dataSource);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
