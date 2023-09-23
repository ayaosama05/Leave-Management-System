using LeaveManagementSystem.API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.API.Models
{
    public class LeaveRequest:BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsCancelled { get; set; }
        public string? Reason { get; set; }

        [ForeignKey("RequestedByEmployeeID")]
        public virtual Employee? RequestedByEmployee { get; set; }
        public int RequestedByEmployeeID { get; set; }

        public int? ApprovedByEmployeeID { get; set; } = null;
        [ForeignKey("ApprovedByEmployeeID")]
        public virtual Employee MApprovedByEmployeeanager { get; set; } = null!;

        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }
        public int LeaveTypeID { get; set; }
    }
}
