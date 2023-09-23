import { Component, OnInit } from '@angular/core';
import { SubordinateDto } from 'src/app/interfaces/SubordinateDto';
import { EmployeeService } from 'src/app/services/employees.service';
import { leaveRequestService } from 'src/app/services/leave-request.service';

@Component({
  selector: 'app-manager-subordinates',
  templateUrl: './manager-subordinates.component.html',
  styleUrls: ['./manager-subordinates.component.css'],
})
export class ManagerSubordinatesComponent implements OnInit {
  data: SubordinateDto[] = [];
  constructor(
    private employeeService: EmployeeService,
    private leaveRequestService: leaveRequestService
  ) {}

  ngOnInit(): void {
    this.employeeService.GetSubordinates().subscribe((response) => {
      console.log(response);
      this.data = response;
    });
  }

  getManagerId() {
    return this.employeeService.getUserID();
  }

  ApproveRequest(requestId: number) {
    this.leaveRequestService
      .ApproveRequest(requestId, this.getManagerId())
      .subscribe((res) => {
        console.log(res);
        window.location.reload();
      });
  }

  RejectRequest(requestId: number) {
    this.leaveRequestService
      .RejectRequest(requestId, this.getManagerId())
      .subscribe((res) => {
        console.log(res);
        window.location.reload();
      });
  }
}
