using Microsoft.AspNetCore.Identity;
using Zaliczenie.Data.Constants;
using Zaliczenie.Data.Entities;

namespace Zaliczenie.StartupConfiguration;

public static class IdentitySeeder
{
    public static async Task SeedAdminAccount(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var user = await userManager.FindByEmailAsync("admin@admin.com");
        if (user is null)
        {
            await userManager.CreateAsync(new()
            {
                Email = "admin@admin.com",
                UserName = "admin@admin.com"
            });
            user = await userManager.FindByEmailAsync("admin@admin.com");
        }

        await userManager.AddPasswordAsync(user!, "SimplePassword123!");
        await userManager.AddToRoleAsync(user!, AppRoles.Admin);
    }

    public static async Task SeedRoles(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await SeedRole(roleManager, AppRoles.CompanyManager);
        await SeedRole(roleManager, AppRoles.Admin);
        await SeedRole(roleManager, AppRoles.Accountant);
    }

    private static async Task SeedRole(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (await roleManager.RoleExistsAsync(roleName)) return;

        await roleManager.CreateAsync(new()
        {
            Name = roleName,
            NormalizedName = roleName.Normalize()
        });
    }
}