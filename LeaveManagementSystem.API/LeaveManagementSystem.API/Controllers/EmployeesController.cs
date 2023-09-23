using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IUserService _userService;

        public EmployeesController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userService.LoginAsync(model);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetSubordinates")]
        public async Task<IActionResult> GetSubordinates([FromQuery] int EmpID)
        {
            var response = await _userService.GetSubordinatesAsync(EmpID);
            return Ok(response);
        }
    }
}
