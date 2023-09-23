import { Injectable } from '@angular/core';
import config from '../../assets/config/config.json';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LeaveTypeDto } from '../interfaces/LeaveTypeDto';
import { map } from 'rxjs';
import { LeaveRequestDto } from '../interfaces/LeaveRequestDto';

@Injectable({
  providedIn: 'root',
})
export class leaveRequestService {
  API_URL = config.api.url + '/api/LeaveRequests';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  Apply(model: LeaveRequestDto) {
    return this.http
      .post<LeaveTypeDto[]>(
        `${this.API_URL}/Apply`,
        { Reason : model.reason,
          StartDate : model.startDate,
          EndDate : model.endDate,
          RequestedByEmployeeID : model.requestedByEmployeeID,
          LeaveTypeID : model.leaveTypeID
        },
        this.httpOptions
      )
      .pipe(
        map((response) => {
          console.log(response);
        })
      );
  }

  ApproveRequest(requestId:number,managerID:number){
    return this.http
    .post(
      `${this.API_URL}/UpdateByManager`,
      { id : requestId,
        isApproved : true,
        approvedByEmployeeID : managerID
      },
      this.httpOptions
    )
    .pipe(
      map((response) => {
        console.log(response);
      })
    );
  }

  RejectRequest(requestId:number,managerID:number){
    return this.http
    .post(
      `${this.API_URL}/UpdateByManager`,
      { id : requestId,
        isApproved : false,
        approvedByEmployeeID : managerID
      },
      this.httpOptions
    )
    .pipe(
      map((response) => {
        console.log(response);
      })
    );
  }
}
