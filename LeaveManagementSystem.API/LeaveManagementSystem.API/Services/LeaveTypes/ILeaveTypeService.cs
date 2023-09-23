namespace LeaveManagementSystem.API.Services
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeDto>> GetTypesListAsync();
    }
}
