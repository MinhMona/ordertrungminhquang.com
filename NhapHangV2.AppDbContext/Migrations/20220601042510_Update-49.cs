using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update49 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionFee",
                table: "WarehouseFrom");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "WarehouseFrom");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "WarehouseFrom");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "WarehouseFrom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdditionFee",
                table: "WarehouseFrom",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "WarehouseFrom",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "WarehouseFrom",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "WarehouseFrom",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
