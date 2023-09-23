using LeaveManagementSystem.API.Helpers;

namespace LeaveManagementSystem.API.Services
{
    public interface ILeaveRequestService
    {
        Task CreateLeaveRequestAsync(CreateLeaveRequestDto model);
        Task<ManagerLeaveApprovalResponseDto> ApplyManagerActionOnLeaveRequestAsync(ManagerLeaveRequestDto model);
        Task CancelLeaveRequestAsync(CancelLeaveRequestDto model);
        double CountVacationDays(DateTime StartDate, DateTime EndDate);
        Task<IEnumerable<LeaveRequestItemDto>> GetAllLeaveRequestsAsync(LeaveRequestParameter Parameters);
    }
}
