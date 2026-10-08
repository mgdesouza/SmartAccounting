using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAccounting.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var administratorRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var contadorRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var usuarioRoleId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[,]
                {
                    { administratorRoleId, "Acesso administrativo completo.", "Administrador", "ADMINISTRADOR", "11111111-1111-1111-1111-111111111111" },
                    { contadorRoleId, "Acesso às funcionalidades contábeis.", "Contador", "CONTADOR", "22222222-2222-2222-2222-222222222222" },
                    { usuarioRoleId, "Acesso básico ao sistema.", "Usuario", "USUARIO", "33333333-3333-3333-3333-333333333333" }
                });

            var adminUserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var contadorUserId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var usuarioUserId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[]
                {
                    "Id", "Nome", "Ativo", "UserName", "NormalizedUserName",
                    "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash",
                    "SecurityStamp", "ConcurrencyStamp", "PhoneNumber",
                    "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd",
                    "LockoutEnabled", "AccessFailedCount"
                },
                values: new object[,]
                {
                    {
                        adminUserId,
                        "Administrador de Teste",
                        true,
                        "admin@smartaccounting.com",
                        "ADMIN@SMARTACCOUNTING.COM",
                        "admin@smartaccounting.com",
                        "ADMIN@SMARTACCOUNTING.COM",
                        true,
                        "AQAAAAMAAYagAAAAEM3trGAbL6rErShhIdhbZW9T3SgXoqH3d7rg1CJvnwXQYZhSwIsztq+luD9RpNPmzQ==",
                        "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
                        "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
                        null,
                        false,
                        false,
                        null,
                        true,
                        0
                    },
                    {
                        contadorUserId,
                        "Contador de Teste",
                        true,
                        "contador@smartaccounting.com",
                        "CONTADOR@SMARTACCOUNTING.COM",
                        "contador@smartaccounting.com",
                        "CONTADOR@SMARTACCOUNTING.COM",
                        true,
                        "AQAAAAMAAYagAAAAEOjqpCvy4qF0yuKwryL8/QmjxidIh2Xlp4E7rabRbLujBdz0/V4kCx2VwIshHTaaYg==",
                        "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb",
                        "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb",
                        null,
                        false,
                        false,
                        null,
                        true,
                        0
                    },
                    {
                        usuarioUserId,
                        "Usuário de Teste",
                        true,
                        "usuario@smartaccounting.com",
                        "USUARIO@SMARTACCOUNTING.COM",
                        "usuario@smartaccounting.com",
                        "USUARIO@SMARTACCOUNTING.COM",
                        true,
                        "AQAAAAMAAYagAAAAEDhDBtLR7ML2nN91P/Obw8um4MNKwDIjJqRALsalVRFP7QhK3o+0atlkQeu5CTPrsg==",
                        "cccccccc-cccc-cccc-cccc-cccccccccccc",
                        "cccccccc-cccc-cccc-cccc-cccccccccccc",
                        null,
                        false,
                        false,
                        null,
                        true,
                        0
                    }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { adminUserId, administratorRoleId },
                    { contadorUserId, contadorRoleId },
                    { usuarioUserId, usuarioRoleId }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var administratorRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var contadorRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var usuarioRoleId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var adminUserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var contadorUserId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var usuarioUserId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { adminUserId, administratorRoleId });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { contadorUserId, contadorRoleId });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { usuarioUserId, usuarioRoleId });

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: adminUserId);

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: contadorUserId);

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: usuarioUserId);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: administratorRoleId);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: contadorRoleId);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: usuarioRoleId);
        }
    }
}
