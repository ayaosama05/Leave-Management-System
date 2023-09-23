using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.API.Seeds
{
    public static class DepartmentsSeeds
    {
        public static void SeedDepartments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
             new Department { Id = 1, Name = "IT" },
             new Department { Id = 2, Name = "HR" },
             new Department { Id = 3, Name = "Operation" },
             new Department { Id = 4, Name = "Facility" },
             new Department { Id = 5, Name = "Management" }
             );
        }
    }
}
