using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.API.Dtos
{
    public class LoginDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
