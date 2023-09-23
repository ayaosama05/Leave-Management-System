using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypesController : ControllerBase
    {
        private ILeaveTypeService _LeaveTypeService;

        public LeaveTypesController(ILeaveTypeService LeaveTypeService)
        {
            _LeaveTypeService = LeaveTypeService;
        }
        //end point to get type of requests
        [HttpGet("GetAllLeaveTypes")]
        public async Task<IActionResult> GetAllLeaveTypes()
        {
            var list = await _LeaveTypeService.GetTypesListAsync();
            return Ok(list);
        }
    }
}
