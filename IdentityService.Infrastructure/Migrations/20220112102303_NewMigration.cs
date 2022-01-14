using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityService.Infrastructure.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserGuid",
                table: "UserDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserGuid",
                table: "UserDetails",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
