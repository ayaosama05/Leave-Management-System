import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { LeaveTypeDto } from 'src/app/interfaces/LeaveTypeDto';
import { leaveTypeService } from 'src/app/services/leave-type.service';
import { leaveRequestService } from 'src/app/services/leave-request.service';
import { LeaveRequestDto } from 'src/app/interfaces/LeaveRequestDto';

@Component({
  selector: 'app-employee-leave-request',
  templateUrl: './employee-leave-request.component.html',
  styleUrls: ['./employee-leave-request.component.css'],
})
export class EmployeeLeaveRequestComponent implements OnInit {
  types: LeaveTypeDto[] = [];
  LeaveRequestForm = new FormGroup({
    startDate: new FormControl('', [Validators.required]),
    endDate: new FormControl('', [Validators.required]),
    reason: new FormControl(),
    leaveTypeID: new FormControl(),
  });
  request: LeaveRequestDto | undefined;
  constructor(
    private leavetypeserive: leaveTypeService,
    private leaveRequestService: leaveRequestService
  ) {}
  ngOnInit(): void {
    this.leavetypeserive.getAllLeaveTypes().subscribe((data) => {
      console.log(data);
      this.types = data;
    });
  }

  onSubmit(): void {
    let requestedByEmployeeID = this.getUserID();
    console.log(requestedByEmployeeID);
    console.log(this.LeaveRequestForm.value);
    this.request = {
      startDate: new Date(this.LeaveRequestForm.value?.startDate || Date.now()),
      endDate: new Date(this.LeaveRequestForm.value?.endDate || Date.now()),
      reason: this.LeaveRequestForm.value.reason,
      requestedByEmployeeID: requestedByEmployeeID,
      leaveTypeID: this.LeaveRequestForm.value.leaveTypeID,
    };

    this.leaveRequestService.Apply(this.request).subscribe((data) => {
      console.log(data);
      alert('Your request has been sent to manager');
      this.LeaveRequestForm.reset();
    });
  }

  getUserID() {
    let employee = window.localStorage.getItem('employee') || '{}';
    let model: EmployeeDto = JSON.parse(employee);
    return model.id;
  }
}
