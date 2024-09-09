using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Crud_Web_App.Services
{
    public static class IdentityDataInitializer
    {
        public static async Task SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            //await SeedAdminUser(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        //private static async Task SeedAdminUser(UserManager<IdentityUser> userManager)
        //{
        //   // var adminEmail = "admin@admin.com";
           // var adminName = "Admin";
           // var adminUser = await userManager.FindByEmailAsync(adminEmail);
           // if (adminUser == null)
           // {
           //     adminUser = new IdentityUser
           //     {
           //         UserName = adminName,
           //         Email = adminEmail,
           //         EmailConfirmed = true
           //     };
           //     var createPowerUser = await userManager.CreateAsync(adminUser, "Admin@123");
           //     if (createPowerUser.Succeeded)
           //     {
           //         await userManager.AddToRoleAsync(adminUser, "Admin");
           //     }
           //     else
           //     {
           //
           //         foreach (var error in createPowerUser.Errors)
           //         {
           //             Console.WriteLine($"Error: {error.Description}");
           //         }
           //     }
           // }
        }
    }
//}
