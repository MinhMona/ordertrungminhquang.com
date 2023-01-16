using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update98 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalerID",
                table: "PayHelp",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalePayHelpPersent",
                table: "Configurations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalerID",
                table: "PayHelp");

            migrationBuilder.DropColumn(
                name: "SalePayHelpPersent",
                table: "Configurations");
        }
    }
}
