using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update96 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FeeService",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SaleTranportationPersent",
                table: "Configurations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeeService",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "SaleTranportationPersent",
                table: "Configurations");
        }
    }
}
