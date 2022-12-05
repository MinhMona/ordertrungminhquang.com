using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageName",
                table: "PageSEO");

            migrationBuilder.RenameColumn(
                name: "OGurl",
                table: "PageSEO",
                newName: "OGUrl");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PageSEO",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PageSEO",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PageSEO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "PageSEO");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PageSEO");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PageSEO");

            migrationBuilder.RenameColumn(
                name: "OGUrl",
                table: "PageSEO",
                newName: "OGurl");

            migrationBuilder.AddColumn<string>(
                name: "PageName",
                table: "PageSEO",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
