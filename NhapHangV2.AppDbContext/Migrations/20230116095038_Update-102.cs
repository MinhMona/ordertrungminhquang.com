using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceVolume",
                table: "SmallPackage",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VolumePayment",
                table: "SmallPackage",
                type: "decimal(18,5)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceVolume",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "VolumePayment",
                table: "SmallPackage");
        }
    }
}
