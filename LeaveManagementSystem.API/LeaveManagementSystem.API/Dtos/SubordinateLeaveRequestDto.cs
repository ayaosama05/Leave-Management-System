using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.API.Dtos
{
    public class SubordinateLeaveRequestDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsCancelled { get; set; }
        public string? LeaveTypeName { get; set; }
    }
}
