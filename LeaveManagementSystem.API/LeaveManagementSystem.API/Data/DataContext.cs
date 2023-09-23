using LeaveManagementSystem.API.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.API.Data
{
    public class DataContext : IdentityDbContext<Employee, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedDepartments();
            modelBuilder.SeedLeaveTypes();

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.LeaveRequests)
                .WithOne(c => c.RequestedByEmployee)
                .HasForeignKey(c => c.RequestedByEmployeeID)
                .OnDelete(DeleteBehavior.Cascade);


        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
