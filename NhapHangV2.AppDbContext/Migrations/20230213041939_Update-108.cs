using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update108 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoogleSiteVerification",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OGLocale",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OGSiteName",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OGType",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReplyTo",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Robots",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationName",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "GoogleSiteVerification",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "OGLocale",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "OGSiteName",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "OGType",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "ReplyTo",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Robots",
                table: "Configurations");
        }
    }
}
