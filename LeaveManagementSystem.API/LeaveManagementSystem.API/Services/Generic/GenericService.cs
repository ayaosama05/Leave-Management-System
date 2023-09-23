using AutoMapper;
using LeaveManagementSystem.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace LeaveManagementSystem.API.Services
{
    public abstract class GenericService
    {
        protected DataContext _context;
        protected readonly IMapper _mapper;

        public GenericService(
           DataContext context,
           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
