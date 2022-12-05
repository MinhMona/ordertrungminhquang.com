using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayInWarehouse",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "FeeWarehouse",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "MainOrderId",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "MainOrderStatus",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "OrderTransactionCode",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "SmallPackageStatus",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "TransportationId",
                table: "OutStockSessionPackage");

            migrationBuilder.DropColumn(
                name: "MainOrderId",
                table: "OutStockSession");

            migrationBuilder.AddColumn<double>(
                name: "WarehouseFee",
                table: "TransportationOrder",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarehouseFee",
                table: "TransportationOrder");

            migrationBuilder.AddColumn<double>(
                name: "DayInWarehouse",
                table: "OutStockSessionPackage",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FeeWarehouse",
                table: "OutStockSessionPackage",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainOrderId",
                table: "OutStockSessionPackage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainOrderStatus",
                table: "OutStockSessionPackage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderTransactionCode",
                table: "OutStockSessionPackage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SmallPackageStatus",
                table: "OutStockSessionPackage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportationId",
                table: "OutStockSessionPackage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainOrderId",
                table: "OutStockSession",
                type: "int",
                nullable: true);
        }
    }
}
