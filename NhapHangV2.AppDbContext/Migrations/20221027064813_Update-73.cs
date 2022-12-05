using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update73 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNotifyAccountant",
                table: "NotificationSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotifyOrderer",
                table: "NotificationSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotifySaler",
                table: "NotificationSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotifyStorekeepers",
                table: "NotificationSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotifyWarehoue",
                table: "NotificationSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotifyWarehoueFrom",
                table: "NotificationSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNotifyAccountant",
                table: "NotificationSetting");

            migrationBuilder.DropColumn(
                name: "IsNotifyOrderer",
                table: "NotificationSetting");

            migrationBuilder.DropColumn(
                name: "IsNotifySaler",
                table: "NotificationSetting");

            migrationBuilder.DropColumn(
                name: "IsNotifyStorekeepers",
                table: "NotificationSetting");

            migrationBuilder.DropColumn(
                name: "IsNotifyWarehoue",
                table: "NotificationSetting");

            migrationBuilder.DropColumn(
                name: "IsNotifyWarehoueFrom",
                table: "NotificationSetting");
        }
    }
}
