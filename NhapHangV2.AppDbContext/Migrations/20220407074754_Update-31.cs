using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportationOrderDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportationOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CODTQCNY = table.Column<double>(type: "float", nullable: true),
                    CODTQVND = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsCheckProduct = table.Column<bool>(type: "bit", nullable: true),
                    IsInsurance = table.Column<bool>(type: "bit", nullable: true),
                    IsPackaged = table.Column<bool>(type: "bit", nullable: true),
                    ProductQuantity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StaffNoteCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationOrderCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransportationOrderId = table.Column<int>(type: "int", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserNote = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationOrderDetail", x => x.Id);
                });
        }
    }
}
