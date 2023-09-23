using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.API.Seeds
{
    public static class LeaveTypesSeeds
    {
        public static void SeedLeaveTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveType>().HasData(
             new LeaveType { Id = 1, Name = "Annual Leave" },
             new LeaveType { Id = 2, Name = "Sick Leave" }
             );
        }
    }
}
