using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartAccounting.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmartAccounting.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        // ============================================================
        // Entity Framework Core
        // ============================================================

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });


        // ============================================================
        // ASP.NET Core Identity
        // ============================================================
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
        {
            // Password
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;

            // User
            options.User.RequireUniqueEmail = true;

            // SignIn
            options.SignIn.RequireConfirmedAccount = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();


        services.AddAuthorization(options =>
        {
            options.AddPolicy("Dashboard.View", policy => policy.RequireClaim("permission", "Dashboard.View"));
            options.AddPolicy("Empresa.View", policy => policy.RequireClaim("permission", "Empresa.View"));
            options.AddPolicy("Empresa.Manage", policy => policy.RequireClaim("permission", "Empresa.Manage"));
            options.AddPolicy("Ecd.View", policy => policy.RequireClaim("permission", "Ecd.View"));
            options.AddPolicy("Ecd.Import", policy => policy.RequireClaim("permission", "Ecd.Import"));
            options.AddPolicy("Contabilidade.View", policy => policy.RequireClaim("permission", "Contabilidade.View"));
            options.AddPolicy("Relatorio.View", policy => policy.RequireClaim("permission", "Relatorio.View"));
            options.AddPolicy("Usuario.Manage", policy => policy.RequireClaim("permission", "Usuario.Manage"));
        });
        
        return services;
    }
}