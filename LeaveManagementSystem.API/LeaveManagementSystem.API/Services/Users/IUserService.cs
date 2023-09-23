namespace LeaveManagementSystem.API.Services
{
    public interface IUserService
    {
        Task<EmployeeDto> LoginAsync(LoginDto model);
        Task<bool> CheckEmployeeBalance(double NuOfDays,int EmployeeID,int LeaveTypeID);
        Task<IEnumerable<SubordinateDto>> GetSubordinatesAsync(int EmployeeID);
        Task ChangeEmployeeBalanceAsync(ManagerLeaveApprovalResponseDto responseDto);
    }
}
