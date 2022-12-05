using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderComment");

            migrationBuilder.RenameColumn(
                name: "TypeContent",
                table: "OrderComment",
                newName: "UID");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "OrderComment",
                newName: "MainOrderId");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "OrderComment",
                newName: "FileLink");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "OrderComment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UID",
                table: "OrderComment",
                newName: "TypeContent");

            migrationBuilder.RenameColumn(
                name: "MainOrderId",
                table: "OrderComment",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "FileLink",
                table: "OrderComment",
                newName: "Link");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "OrderComment",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "OrderComment",
                type: "bit",
                nullable: true);
        }
    }
}
