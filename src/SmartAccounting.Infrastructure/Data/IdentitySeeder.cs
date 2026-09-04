using Microsoft.AspNetCore.Identity;
using SmartAccounting.Domain.Security;

namespace SmartAccounting.Infrastructure.Data;

public static class IdentitySeeder
{
    public static readonly string[] Roles =
    [
        "Administrador",
        "Contador",
        "Analista",
        "Usuario"
    ];

    public static readonly string[] Permissions =
    [
        Permission.DashboardView,
        Permission.EmpresaView,
        Permission.EmpresaManage,
        Permission.EcdView,
        Permission.EcdImport,
        Permission.ContabilidadeView,
        Permission.RelatorioView,
        Permission.UsuarioManage
    ];

    public static async Task SeedAsync(
        RoleManager<IdentityRole<int>> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        foreach (var roleName in Roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(roleName));
            }
        }

        var administrator = await roleManager.FindByNameAsync("Administrador");
        if (administrator is not null)
        {
            foreach (var permission in Permissions)
            {
                var exists = await roleManager.GetClaimsAsync(administrator);
                if (!exists.Any(x => x.Type == "permission" && x.Value == permission))
                {
                    await roleManager.AddClaimAsync(administrator, new System.Security.Claims.Claim("permission", permission));
                }
            }
        }
    }
}
