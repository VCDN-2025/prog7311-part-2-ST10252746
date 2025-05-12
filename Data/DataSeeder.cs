using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace PROG7311_POE_PART_2.Data
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Employee", "Farmer" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Seed Employee User
            var employeeEmail = "employee@agrienergy.com";
            var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
            if (employeeUser == null)
            {
                employeeUser = new IdentityUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(employeeUser, "Employee@123");
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }

            // Seed Farmer User
            var farmerEmail = "farmer@agrienergy.com";
            var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
            if (farmerUser == null)
            {
                farmerUser = new IdentityUser
                {
                    UserName = farmerEmail,
                    Email = farmerEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(farmerUser, "Farmer@123");
                await userManager.AddToRoleAsync(farmerUser, "Farmer");
            }
        }
    }
}
