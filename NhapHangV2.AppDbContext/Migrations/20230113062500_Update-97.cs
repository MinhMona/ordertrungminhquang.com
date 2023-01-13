using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update97 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayHelpOrderId",
                table: "StaffIncome",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportationOrderId",
                table: "StaffIncome",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayHelpOrderId",
                table: "StaffIncome");

            migrationBuilder.DropColumn(
                name: "TransportationOrderId",
                table: "StaffIncome");
        }
    }
}
