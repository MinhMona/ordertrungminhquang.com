using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayHelpTemp");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "PayHelpDetail");

            migrationBuilder.DropColumn(
                name: "FriendsAccount",
                table: "PayHelpDetail");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PayHelpDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "PayHelpDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FriendsAccount",
                table: "PayHelpDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "PayHelpDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PayHelpTemp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Desc1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FriendsAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    UID = table.Column<int>(type: "int", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayHelpTemp", x => x.Id);
                });
        }
    }
}
