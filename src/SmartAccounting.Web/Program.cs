using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartAccounting.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
})
.AddRoles<IdentityRole<int>>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
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

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    await IdentitySeeder.SeedAsync(roleManager, userManager);
}

app.MapRazorPages();

app.Run();
