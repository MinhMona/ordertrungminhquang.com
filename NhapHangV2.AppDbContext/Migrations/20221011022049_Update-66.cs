using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainOrderID",
                table: "OutStockSessionPackage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderTransactionCode",
                table: "OutStockSessionPackage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportationID",
                table: "OutStockSessionPackage",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainOrderID",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "OrderTransactionCode",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "TransportationID",
                table: "OutStockSessionPackage");
        }
    }
}
