using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.API.Models
{
    public class Employee : IdentityUser<int>
    {
        #region Professional Data
        public byte AnnualLeaveBalance { get; set; } = 21;
        public byte SickLeaveBalance { get; set; } = 30;
        public string jobtitle { get; set; } = string.Empty;
        public DateTime HiringDate { get; set; }

        public bool IsActive { get; set; } = true;
        #endregion

        #region Perosnal data
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public byte[]? ProfileImage { get; set; }
        #endregion

        #region navigation property
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int? ManagerId { get; set; } = null;
        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; } = null!;
        public virtual ICollection<Employee> Subordinates { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
        #endregion
    }
}
