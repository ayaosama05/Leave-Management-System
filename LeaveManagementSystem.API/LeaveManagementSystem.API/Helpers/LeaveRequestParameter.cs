namespace LeaveManagementSystem.API.Helpers
{
    public class LeaveRequestParameter : PaginatedParameters
    {
        public bool? IsCancelled { get; set; } = null;
        public bool? IsApproved { get; set; } = null;
    }
}
