using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update72 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsWarehouseFrom",
                table: "WarehouseFrom",
                newName: "IsChina");

            migrationBuilder.RenameColumn(
                name: "IsWarehouse",
                table: "Warehouse",
                newName: "IsChina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsChina",
                table: "WarehouseFrom",
                newName: "IsWarehouseFrom");

            migrationBuilder.RenameColumn(
                name: "IsChina",
                table: "Warehouse",
                newName: "IsWarehouse");
        }
    }
}
