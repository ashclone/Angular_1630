import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { employee } from '../infrastructure/employee.interface';
import { Observable } from 'rxjs/internal/Observable';
import { Hobbies } from '../infrastructure/hobbies.interface';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private baseApiUrl = 'https://localhost:7223"';

  constructor(private httpClient: HttpClient) {}
  getAllEmployees(): Observable<employee[]> {
    return this.httpClient.get<employee[]>('https://localhost:7223/api/Vm');
  }
  getAllHobbies(): Observable<Hobbies[]> {
    return this.httpClient.get<Hobbies[]>('https://localhost:7223/api/Hobby');
  }
  getEmployee(id: number): Observable<employee> {
    return this.httpClient.get<employee>(
      'https://localhost:7223/api/Vm/Details' + id
    );
  }
  deleteEmployee(id: number): Observable<any> {
    return this.httpClient.delete<any>('https://localhost:7223/api/Vm/' + id);
  }
  addEmployee(employee: employee): Observable<any> {
    return this.httpClient.post<any>('https://localhost:7223/api/Vm', employee);
  }
  updateEmployee(employee: employee): Observable<any> {
    return this.httpClient.put<any>('https://localhost:7223/api/Vm', employee);
  }
}
