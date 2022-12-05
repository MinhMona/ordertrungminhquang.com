using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeLine",
                table: "MainOrder");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "MainOrder",
                newName: "ReceiverPhone");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "MainOrder",
                newName: "ReceiverFullName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "MainOrder",
                newName: "ReceiverEmail");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "MainOrder",
                newName: "DeliveryAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceiverPhone",
                table: "MainOrder",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ReceiverFullName",
                table: "MainOrder",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "ReceiverEmail",
                table: "MainOrder",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "MainOrder",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "TimeLine",
                table: "MainOrder",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
