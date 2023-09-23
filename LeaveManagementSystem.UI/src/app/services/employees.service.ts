import { Injectable } from '@angular/core';
import config from '../../assets/config/config.json';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
import { EmployeeDto } from '../interfaces/EmployeeDto';
import { SubordinateDto } from '../interfaces/SubordinateDto';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  API_URL = config.api.url + '/api/Employees';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  GetSubordinates() {
    const employeeID = this.getUserID();
    return this.http
      .get<SubordinateDto[]>(
        `${this.API_URL}/GetSubordinates?EmpID=${employeeID}`,
        this.httpOptions
      )
      .pipe(
        map((response) => {
          return response;
        })
      );
  }

  getUserID() {
    let employee = window.localStorage.getItem('employee') || '{}';
    let model: EmployeeDto = JSON.parse(employee);
    return model.id;
  }
}
