using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update68 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TransportationOrder",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TransportationOrder");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "TransportationOrder");
        }
    }
}
