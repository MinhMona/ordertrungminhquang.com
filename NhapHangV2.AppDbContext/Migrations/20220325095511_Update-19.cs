using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainOrderId",
                table: "RequestOutStock");

            migrationBuilder.DropColumn(
                name: "TransportationId",
                table: "RequestOutStock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainOrderId",
                table: "RequestOutStock",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportationId",
                table: "RequestOutStock",
                type: "int",
                nullable: true);
        }
    }
}
