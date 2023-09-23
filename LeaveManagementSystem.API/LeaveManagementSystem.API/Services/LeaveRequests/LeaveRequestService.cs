using LeaveManagementSystem.API.Data;
using LeaveManagementSystem.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.API.Services
{
    public class LeaveRequestService : GenericService, ILeaveRequestService
    {
        public LeaveRequestService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public double CountVacationDays(DateTime StartDate, DateTime EndDate)
        {
            // later, we'll exclude holidays
            return (EndDate.Date - StartDate.Date).TotalDays + 1;
        }
        public async Task CreateLeaveRequestAsync(CreateLeaveRequestDto model)
        {
            var request = _mapper.Map<LeaveRequest>(model);
            await _context.LeaveRequests.AddAsync(request);
            await SaveChangesAsync();
        }
        public async Task<ManagerLeaveApprovalResponseDto> ApplyManagerActionOnLeaveRequestAsync(ManagerLeaveRequestDto model)
        {
            var request =
              await _context.LeaveRequests.FindAsync(model.Id);

            request.IsApproved = model.IsApproved;
            request.ApprovedByEmployeeID = model.ApprovedByEmployeeID;
            request.UpdatedAt = DateTime.Now;

            _context.LeaveRequests.Update(request);
            await SaveChangesAsync();

            double days = CountVacationDays(request.StartDate,request.EndDate);
            return new ManagerLeaveApprovalResponseDto(request.RequestedByEmployeeID, days,request.LeaveTypeID);
        }
        public async Task CancelLeaveRequestAsync(CancelLeaveRequestDto model)
        {
            var request =
                await _context.LeaveRequests.FindAsync(model.Id);

            request.IsCancelled = true;
            request.UpdatedAt = DateTime.Now;
            _context.LeaveRequests.Update(request);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<LeaveRequestItemDto>> GetAllLeaveRequestsAsync(LeaveRequestParameter Parameters)
        {
            var requests = await _context.LeaveRequests
                .Where(a => (Parameters.IsCancelled == null || a.IsCancelled == Parameters.IsCancelled)
                && (Parameters.IsApproved == null || a.IsApproved == Parameters.IsApproved))
                .OrderBy(on => on.CreatedAt).ToListAsync();

          // var totalCount = requests.Count();
          // var metadata = new
          // {
          //     TotalCount,
          //     PageSize,
          //     CurrentPage,
          //     TotalPages,
          // };

            requests = requests
                        .Skip((Parameters.PageNumber - 1) * Parameters.PageSize)
                        .Take(Parameters.PageSize).ToList();

            var requestsDtos = _mapper.Map<IEnumerable<LeaveRequestItemDto>>(requests);
            return requestsDtos;
        }
    }
}
