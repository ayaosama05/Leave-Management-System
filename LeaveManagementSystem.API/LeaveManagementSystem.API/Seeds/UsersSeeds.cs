using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.API.Seeds
{
    public class UsersSeeds
    {
        public static async Task SeedAsync(UserManager<Employee> userManager)
        {
            if (!userManager.Users.Any())
            {
                var mngr = new Employee
                {
                    UserName = "Aya_Osama",
                    FullName = "Aya Osama Mohammed",
                    Email = "aya_osama0508@gmail.com",
                    IsActive = true,
                    DepartmentId = 1
                };

                await userManager.CreateAsync(mngr, "Aa@123456");
                await userManager.AddToRoleAsync(mngr, "Manager");

                var employee = new Employee
                {
                    UserName = "emp_user",
                    FullName = "Employee User Full Name",
                    Email = "emp_user@gmail.com",
                    IsActive = true,
                    DepartmentId = 1
                };

                await userManager.CreateAsync(employee, "Bb@123456");
                await userManager.AddToRoleAsync(employee, "Employee");

                var admin = new Employee
                {
                    UserName = "admin_user",
                    FullName = "Admin User Full Name",
                    Email = "admin_user@gmail.com",
                    IsActive = true,
                    DepartmentId = 1
                };

                await userManager.CreateAsync(admin, "Cc@123456");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
