using LeaveManagementSystem.API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.API.Models
{
    public class Department:BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
