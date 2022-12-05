using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update63 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InsuranceMoney",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckProduct",
                table: "TransportationOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IsCheckProductPrice",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFastDelivery",
                table: "TransportationOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IsFastDeliveryPrice",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInsurance",
                table: "TransportationOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPacked",
                table: "TransportationOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IsPackedPrice",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceMoney",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "IsCheckProduct",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "IsCheckProductPrice",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "IsFastDelivery",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "IsFastDeliveryPrice",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "IsInsurance",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "IsPacked",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "IsPackedPrice",
                table: "TransportationOrder");
        }
    }
}
