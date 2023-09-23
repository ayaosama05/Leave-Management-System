using LeaveManagementSystem.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveRequestsController : ControllerBase
    {
        private ILeaveRequestService _leaveRequestService;
        private IUserService _userSerivce;

        public LeaveRequestsController(ILeaveRequestService leaveRequestService, IUserService userSerivce)
        {
            _leaveRequestService = leaveRequestService;
            _userSerivce = userSerivce;
        }

        //end point to apply for leave request
        [HttpPost("Apply")]
        public async Task<IActionResult> ApplyForLeaveRequest([FromBody] CreateLeaveRequestDto request)
        {
            try
            {
                var numberOfDays = _leaveRequestService.CountVacationDays(request.StartDate,request.EndDate);
                var flag = await _userSerivce.CheckEmployeeBalance(numberOfDays, request.RequestedByEmployeeID, request.LeaveTypeID);

                if (!flag)
                    return BadRequest("No Available balance");

                await _leaveRequestService.CreateLeaveRequestAsync(request);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //end point for manager to approve or reject
        [HttpPost("UpdateByManager")]
        public async Task<IActionResult> UpdateLeaveRequestByManager([FromBody] ManagerLeaveRequestDto request)
        {
            try
            {
                var response = await _leaveRequestService.ApplyManagerActionOnLeaveRequestAsync(request);
                if (request.IsApproved == true && response != null)
                    await _userSerivce.ChangeEmployeeBalanceAsync(response);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //end point for employee to cancel his request
        [HttpPost("Cancel")]
        public async Task<IActionResult> CancelLeaveRequest([FromBody] CancelLeaveRequestDto model)
        {
            try
            {
                await _leaveRequestService.CancelLeaveRequestAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLeaveRequests([FromQuery] LeaveRequestParameter Parameters)
        {
            try
            {
                var list = await _leaveRequestService.GetAllLeaveRequestsAsync(Parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
