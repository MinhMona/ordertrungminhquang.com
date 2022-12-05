using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update74 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OneSignalPlayerID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OneSignalAppID",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestAPIKey",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneSignalPlayerID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OneSignalAppID",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "RestAPIKey",
                table: "Configurations");
        }
    }
}
