using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartAccounting.Infrastructure.Data;

namespace SmartAccounting.Infrastructure.Data;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(
        IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context =
            scope.ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

        // ============================================================
        // Aplica as migrations
        // ============================================================

        await context.Database.MigrateAsync();

        // ============================================================
        // Inicializa Roles
        // ============================================================

        var roleManager =
            scope.ServiceProvider
                .GetRequiredService<RoleManager<ApplicationRole>>();

        await SeedRolesAsync(roleManager);

        // ============================================================
        // Inicializa usuário administrador
        // ============================================================

        var userManager =
            scope.ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

        await SeedUsersAsync(userManager);
    }

    private static async Task SeedRolesAsync(
        RoleManager<ApplicationRole> roleManager)
    {
        string[] roles =
        {
            "Administrator",
            "User"
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(
                    new ApplicationRole
                    {
                        Name = role
                    });
            }
        }
    }

    private static async Task SeedUsersAsync(
        UserManager<ApplicationUser> userManager)
    {
        const string email = "admin@smartaccounting.com";
        const string password = "Admin123";

        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(
                user,
                password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(
                    user,
                    "Administrator");
            }
        }
    }
}

