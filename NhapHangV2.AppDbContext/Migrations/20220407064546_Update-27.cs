using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassIcon",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "MenuClass",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "CustomerBenefits");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "CustomerBenefits",
                newName: "IMG");

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuLink",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IMG",
                table: "CustomerBenefits",
                newName: "Icon");

            migrationBuilder.AddColumn<string>(
                name: "ClassIcon",
                table: "Step",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Step",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "Menu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuLink",
                table: "Menu",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuClass",
                table: "Menu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Target",
                table: "Menu",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "CustomerBenefits",
                type: "bit",
                nullable: true);
        }
    }
}
