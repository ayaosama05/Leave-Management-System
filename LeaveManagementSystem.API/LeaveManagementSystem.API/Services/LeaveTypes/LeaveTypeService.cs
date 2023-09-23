using LeaveManagementSystem.API.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.API.Services
{
    public class LeaveTypeService : GenericService , ILeaveTypeService
    {
        public LeaveTypeService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<LeaveTypeDto>> GetTypesListAsync()
        {
            var list = await _context.LeaveTypes.ToListAsync();
            var listDtos = _mapper.Map<List<LeaveTypeDto>>(list);
            return listDtos;
        }
    }
}
