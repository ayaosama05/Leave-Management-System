namespace LeaveManagementSystem.API.Dtos
{
    public class SubordinateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Jobtitle { get; set; }
        public byte AnnualLeaveBalance { get; set; }
        public byte SickLeaveBalance { get; set; }
        public string Department { get; set; }
        public List<SubordinateLeaveRequestDto> LeaveRequestItemDtos { get; set; } = new List<SubordinateLeaveRequestDto>();
    }
}
