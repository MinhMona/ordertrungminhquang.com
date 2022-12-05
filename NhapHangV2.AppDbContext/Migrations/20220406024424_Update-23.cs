using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndexPos",
                table: "PageType");

            migrationBuilder.DropColumn(
                name: "NodeAliasPath",
                table: "PageType");

            migrationBuilder.DropColumn(
                name: "NodeID",
                table: "PageType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndexPos",
                table: "PageType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NodeAliasPath",
                table: "PageType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NodeID",
                table: "PageType",
                type: "int",
                nullable: true);
        }
    }
}
