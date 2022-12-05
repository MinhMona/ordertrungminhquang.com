using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpLevel",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FeeTQVNPerVolume",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TienTichLuy",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpLevel",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeeTQVNPerVolume",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TienTichLuy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
