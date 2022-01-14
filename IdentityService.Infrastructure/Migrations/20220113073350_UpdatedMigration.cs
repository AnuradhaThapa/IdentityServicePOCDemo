using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityService.Infrastructure.Migrations
{
    public partial class UpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApiId",
                table: "UserDetails",
                newName: "AplId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AplId",
                table: "UserDetails",
                newName: "ApiId");
        }
    }
}
