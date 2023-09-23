namespace LeaveManagementSystem.API.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Jobtitle { get; set; }
        public string Role { get; set; }
        public byte AnnualLeaveBalance { get; set; }
        public byte SickLeaveBalance { get; set; }
        public string Department { get; set; }
    }
}
