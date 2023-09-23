import { SubordinateLeaveRequestDto } from './SubordinateleaveRequestDto';

export interface SubordinateDto {
  annualLeaveBalance: number;
  sickLeaveBalance: number;
  department: string;
  fullName: string;
  id: number;
  jobtitle: string;
  leaveRequestItemDtos: SubordinateLeaveRequestDto[];
}
