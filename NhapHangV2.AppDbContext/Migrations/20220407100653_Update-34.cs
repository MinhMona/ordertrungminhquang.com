using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionFeeCNY",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "AdditionFeeVND",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "BarCode",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "SensorFeeCNY",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "SensorFeeVND",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "TransportationOrder");

            migrationBuilder.AddColumn<double>(
                name: "AdditionFeeCNY",
                table: "SmallPackage",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AdditionFeeVND",
                table: "SmallPackage",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SensorFeeCNY",
                table: "SmallPackage",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SensorFeeVND",
                table: "SmallPackage",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionFeeCNY",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "AdditionFeeVND",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "SensorFeeCNY",
                table: "SmallPackage");

            migrationBuilder.DropColumn(
                name: "SensorFeeVND",
                table: "SmallPackage");

            migrationBuilder.AddColumn<double>(
                name: "AdditionFeeCNY",
                table: "TransportationOrder",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AdditionFeeVND",
                table: "TransportationOrder",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                table: "TransportationOrder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SensorFeeCNY",
                table: "TransportationOrder",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SensorFeeVND",
                table: "TransportationOrder",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "TransportationOrder",
                type: "float",
                nullable: true);
        }
    }
}
