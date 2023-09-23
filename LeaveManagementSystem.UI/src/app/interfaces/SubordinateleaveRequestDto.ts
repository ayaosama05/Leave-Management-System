export interface SubordinateLeaveRequestDto {
  id: number;
  createdAt: Date;
  endDate: Date;
  startDate: Date;
  leaveTypeName: string;
  isApproved: boolean;
  isCancelled: boolean;
}
