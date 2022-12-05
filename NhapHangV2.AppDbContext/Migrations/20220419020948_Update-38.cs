using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notification",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NotificationContent",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToUserId",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "NotificationContent",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "Notification");
        }
    }
}
