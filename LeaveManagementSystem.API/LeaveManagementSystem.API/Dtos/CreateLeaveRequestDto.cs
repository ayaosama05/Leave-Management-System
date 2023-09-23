using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.API.Dtos
{
    public class CreateLeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        public int RequestedByEmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
    }
}
