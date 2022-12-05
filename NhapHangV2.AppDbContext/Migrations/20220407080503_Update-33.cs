using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "BG");

            migrationBuilder.DropTable(
                name: "Commitment");

            migrationBuilder.DropColumn(
                name: "FeeVolume",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "FeeVolumeCK",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "IsFlow",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "IsGiaohang",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "OrderVolume",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "QuantityMDH",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "QuantityMVD",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "StatusPackage",
                table: "MainOrder");

            migrationBuilder.DropColumn(
                name: "TQVNVolume",
                table: "MainOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeeVolume",
                table: "MainOrder",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeeVolumeCK",
                table: "MainOrder",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFlow",
                table: "MainOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGiaohang",
                table: "MainOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderVolume",
                table: "MainOrder",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityMDH",
                table: "MainOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityMVD",
                table: "MainOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusPackage",
                table: "MainOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TQVNVolume",
                table: "MainOrder",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BenefitIndex = table.Column<int>(type: "int", nullable: true),
                    BenefitSide = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DescOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commitment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Index = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commitment", x => x.Id);
                });
        }
    }
}
