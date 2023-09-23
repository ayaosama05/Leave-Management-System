export interface LeaveRequestDto {
  startDate: Date;
  endDate: Date;
  reason: string;
  requestedByEmployeeID: number;
  leaveTypeID: number;
}
