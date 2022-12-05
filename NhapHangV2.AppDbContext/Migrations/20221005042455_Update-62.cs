using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YoutubeLink",
                table: "Configurations",
                newName: "Youtube");

            migrationBuilder.AddColumn<string>(
                name: "GoogleMapLink",
                table: "Configurations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleMapLink",
                table: "Configurations");

            migrationBuilder.RenameColumn(
                name: "Youtube",
                table: "Configurations",
                newName: "YoutubeLink");
        }
    }
}
