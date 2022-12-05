using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckProduct",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "IsInsurance",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "IsPackaged",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "SmallPackage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckProduct",
                table: "SmallPackage",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInsurance",
                table: "SmallPackage",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPackaged",
                table: "SmallPackage",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "SmallPackage",
                type: "int",
                nullable: true);
        }
    }
}
