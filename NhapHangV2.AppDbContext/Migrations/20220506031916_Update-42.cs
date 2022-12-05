using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "SmallPackage",
                newName: "FloatingUserPhone");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "SmallPackage",
                newName: "FloatingUserName");

            migrationBuilder.RenameColumn(
                name: "StatusConfirm",
                table: "SmallPackage",
                newName: "FloatingStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FloatingUserPhone",
                table: "SmallPackage",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "FloatingUserName",
                table: "SmallPackage",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FloatingStatus",
                table: "SmallPackage",
                newName: "StatusConfirm");
        }
    }
}
