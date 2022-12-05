using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WareHouseTQ",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WareHouseVN",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentPlace",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "SmallPackageCode",
                table: "RequestOutStock");

            migrationBuilder.DropColumn(
                name: "WareHouseName",
                table: "HistoryScanPackage");

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "HistoryScanPackage",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "HistoryScanPackage");

            migrationBuilder.AddColumn<int>(
                name: "WareHouseTQ",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WareHouseVN",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentPlace",
                table: "SmallPackage",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallPackageCode",
                table: "RequestOutStock",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WareHouseName",
                table: "HistoryScanPackage",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
