using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeeWarehouseOutCNY",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "FeeWarehouseOutVND",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "FeeWarehouseWeightCNY",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "FeeWarehouseWeightVND",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "WeightNonQD",
                table: "TransportationOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FeeWarehouseOutCNY",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FeeWarehouseOutVND",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FeeWarehouseWeightCNY",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FeeWarehouseWeightVND",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightNonQD",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);
        }
    }
}
