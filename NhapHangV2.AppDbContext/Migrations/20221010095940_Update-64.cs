using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFastDelivery",
                table: "TransportationOrder");

            migrationBuilder.RenameColumn(
                name: "IsFastDeliveryPrice",
                table: "TransportationOrder",
                newName: "DeliveryPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryPrice",
                table: "TransportationOrder",
                newName: "IsFastDeliveryPrice");

            migrationBuilder.AddColumn<bool>(
                name: "IsFastDelivery",
                table: "TransportationOrder",
                type: "bit",
                nullable: true);
        }
    }
}
