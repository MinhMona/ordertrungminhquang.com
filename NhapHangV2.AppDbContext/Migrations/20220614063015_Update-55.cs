using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "PermitObjectPermissions");

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "PermitObjectPermissions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "PermitObjectPermissions");

            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "PermitObjectPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
