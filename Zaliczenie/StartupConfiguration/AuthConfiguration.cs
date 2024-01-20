using Microsoft.AspNetCore.Identity;
using Zaliczenie.Data;
using Zaliczenie.Data.Entities;

namespace Zaliczenie.StartupConfiguration;

public static class AuthConfiguration
{
    public static void SetupAuth(this WebApplicationBuilder builder)
    {
        builder.Services.AddDefaultIdentity<User>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }
}