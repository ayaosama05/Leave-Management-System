import { Injectable } from '@angular/core';
import config from '../../assets/config/config.json';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LeaveTypeDto } from '../interfaces/LeaveTypeDto';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class leaveTypeService {
  API_URL = config.api.url + '/api/LeaveTypes/GetAllLeaveTypes';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  getAllLeaveTypes() {
    return this.http
      .get<LeaveTypeDto[]>(`${this.API_URL}`, this.httpOptions)
      .pipe(
        map((list: LeaveTypeDto[]) => {
          return list;
        })
      );
  }
}
