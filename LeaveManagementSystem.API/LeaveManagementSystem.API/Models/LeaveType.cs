using LeaveManagementSystem.API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.API.Models
{
    public class LeaveType:BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
