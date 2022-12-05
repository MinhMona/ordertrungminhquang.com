using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update53 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IsCheckProductPriceCNY",
                table: "MainOrder",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IsPackedPriceCNY",
                table: "MainOrder",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckProductPriceCNY",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "IsPackedPriceCNY",
                table: "MainOrder");
        }
    }
}
