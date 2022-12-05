using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update65 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsOutStockOrder",
                table: "OutStockSession",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsOutStockTrans",
                table: "OutStockSession",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOutStockOrder",
                table: "OutStockSession");

            migrationBuilder.DropColumn(
                name: "IsOutStockTrans",
                table: "OutStockSession");
        }
    }
}
