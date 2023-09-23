namespace LeaveManagementSystem.API.Dtos
{
    public class ManagerLeaveApprovalResponseDto
    {
        public ManagerLeaveApprovalResponseDto(int EmpID,double days, int vacationType)
        {
            EmployeeID = EmpID;
            VacationDays = days;
            VacationType = vacationType;
        }

        public int EmployeeID { get; set; }
        public double VacationDays { get; set; }
        public int VacationType { get; set; }
    }
}
