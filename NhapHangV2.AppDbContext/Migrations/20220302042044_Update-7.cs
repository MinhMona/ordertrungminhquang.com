using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VIPLevel",
                table: "Users");

            migrationBuilder.AlterColumn<double>(
                name: "OrderWeight",
                table: "MainOrder",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VIPLevel",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "OrderWeight",
                table: "MainOrder",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
