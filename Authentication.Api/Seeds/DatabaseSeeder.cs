using Authentication.Core.Data;
using Authentication.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Api.Seeds
{
    public class DatabaseSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider services)
        {
            var logger = services.GetRequiredService<ILogger<DatabaseSeeder>>();
            try
            {
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                // Uppercase role names (e.g., "ADMIN" instead of "Admin")
                string[] roles = { "ADMIN", "PATIENT", "DOCTOR", "PHARMACIST", "DELIVERYMAN" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // Seed admin user (assign "ADMIN" role)
                var adminEmail = "admin@rxora.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FullName = "Admin"
                    };
                    await userManager.CreateAsync(adminUser, "Admin@1234");
                    await userManager.AddToRoleAsync(adminUser, "ADMIN"); // Match uppercase role name
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Seeding failed!");
            }
        }
    }
}
