using AutoMapper;
using LeaveManagementSystem.API.Data;
using LeaveManagementSystem.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LeaveManagementSystem.API.Services
{
    public class UserService : GenericService, IUserService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IConfiguration _configuration;
        public UserService(DataContext context, IMapper mapper,
             UserManager<Employee> userManager,
             IConfiguration configuration) : base(context, mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<EmployeeDto> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.username);

            //Validate
            if (user is null)
                user = await _userManager.FindByEmailAsync(model.username);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.password))
                throw new ArgumentException($"Wrong username or password");

            // authentication successful
            var roles = await _userManager.GetRolesAsync(user);
            var jwtSewcurityToken = await GenerateToken(user, roles);
            var response = _mapper.Map<EmployeeDto>(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSewcurityToken);
            response.Department = await GetUserDepartment(user.DepartmentId);
            response.Role = roles.First();
            return response;
        }
        private async Task<string> GetUserDepartment(int DepartmentId)
        {
            var dept = await _context.Departments.FindAsync(DepartmentId);
            return dept.Name;
        }
        private async Task<JwtSecurityToken> GenerateToken(Employee User, IList<string> userRoles)
        {
            var userClaims = await _userManager.GetClaimsAsync(User);
            var roleClaims = new List<Claim>();

            foreach (var role in userRoles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,User.UserName),
                new Claim(ClaimTypes.Email,User.Email),
            }.Union(userClaims)
            .Union(roleClaims);

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

        public async Task<bool> CheckEmployeeBalance(double NuOfDays, int EmployeeID, int LeaveTypeID)
        {
            var user = await _userManager.FindByIdAsync(EmployeeID.ToString());
            if (user is not null)
                return checkAvaialbeBalanceByType(NuOfDays, user, LeaveTypeID);

            return false;
        }

        private bool checkAvaialbeBalanceByType(double NuOfDays, Employee emp, int LeaveTypeID)
        {
            if (LeaveTypeID == 1) //Annual Leave
                return emp.AnnualLeaveBalance >= NuOfDays;

            if (LeaveTypeID == 2)
                return emp.SickLeaveBalance >= NuOfDays;

            throw new Exception("There's no balance for this vacation");
        }

        public async Task<IEnumerable<SubordinateDto>> GetSubordinatesAsync(int EmployeeID){
               var user = await _userManager.FindByIdAsync(EmployeeID.ToString());
            var subordinates = await _context.Users.Where(a => a.ManagerId == EmployeeID)
             .Include(a => a.Department)
             .Include(a => a.LeaveRequests)
             .ThenInclude(b => b.LeaveType)
             .ToListAsync();

            var subordinatesDtos = _mapper.Map<List<SubordinateDto>>(subordinates);
            return subordinatesDtos;
        }  

        public async Task ChangeEmployeeBalanceAsync(ManagerLeaveApprovalResponseDto responseDto)
        {
            var user = await _userManager.FindByIdAsync(responseDto.EmployeeID.ToString());

            byte days = (byte)responseDto.VacationDays;
            if (responseDto.VacationType == 1) //Annual Leave
                user.AnnualLeaveBalance -= days;
            else
                user.SickLeaveBalance -= days;

            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
