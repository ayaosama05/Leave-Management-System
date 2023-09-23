using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;

namespace LeaveManagementSystem.API.Seeds
{
    public static class RolesSeeds
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                string[] roles = new string[] { "Employee", "Admin", "Manager" };

                foreach (string role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
                }
            }
        }
    }
}
