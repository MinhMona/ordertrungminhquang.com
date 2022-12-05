using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionFee",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Warehouse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdditionFee",
                table: "Warehouse",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Warehouse",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Warehouse",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Warehouse",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
