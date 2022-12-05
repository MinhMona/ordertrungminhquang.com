using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuLink",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "Menu",
                newName: "Link");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Menu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Menu",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menu",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Menu",
                newName: "MenuName");

            migrationBuilder.AddColumn<string>(
                name: "MenuLink",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
