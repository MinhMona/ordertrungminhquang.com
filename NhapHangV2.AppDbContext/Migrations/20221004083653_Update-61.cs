using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update61 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundAuth",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundAuth",
                table: "Configurations");
        }
    }
}
