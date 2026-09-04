using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartAccounting.Domain.Entities;

namespace SmartAccounting.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Exercicio> Exercicios => Set<Exercicio>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Empresa>(entity =>
        {
            entity.ToTable("Empresa");
            entity.HasKey(x => x.EmpresaId);
            entity.Property(x => x.Cnpj).HasMaxLength(14).IsRequired();
            entity.Property(x => x.RazaoSocial).HasMaxLength(200).IsRequired();
            entity.Property(x => x.NomeFantasia).HasMaxLength(200);
            entity.HasIndex(x => x.Cnpj).IsUnique();
        });

        builder.Entity<Exercicio>(entity =>
        {
            entity.ToTable("Exercicio");
            entity.HasKey(x => x.ExercicioId);
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.ArquivoECD).HasMaxLength(500);

            entity.HasOne(x => x.Empresa)
                .WithMany(x => x.Exercicios)
                .HasForeignKey(x => x.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(x => new { x.EmpresaId, x.Ano }).IsUnique();
        });

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("Usuario");
            entity.Property(x => x.Nome).HasMaxLength(200).IsRequired();
        });

        builder.Entity<IdentityRole<int>>(entity => entity.ToTable("Role"));
        builder.Entity<IdentityUserRole<int>>(entity => entity.ToTable("UsuarioRole"));
        builder.Entity<IdentityUserClaim<int>>(entity => entity.ToTable("UsuarioClaim"));
        builder.Entity<IdentityUserLogin<int>>(entity => entity.ToTable("UsuarioLogin"));
        builder.Entity<IdentityRoleClaim<int>>(entity => entity.ToTable("RoleClaim"));
        builder.Entity<IdentityUserToken<int>>(entity => entity.ToTable("UsuarioToken"));
    }
}
