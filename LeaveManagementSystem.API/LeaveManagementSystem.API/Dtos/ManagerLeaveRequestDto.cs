namespace LeaveManagementSystem.API.Dtos
{
    public class ManagerLeaveRequestDto
    {
        public int Id { get; set; }
        public bool? IsApproved { get; set; }
        public int ApprovedByEmployeeID { get; set; }
    }
}
