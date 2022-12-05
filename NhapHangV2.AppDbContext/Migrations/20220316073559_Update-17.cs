using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptBy",
                table: "Withdraw");

            migrationBuilder.DropColumn(
                name: "AcceptDate",
                table: "Withdraw");

            migrationBuilder.DropColumn(
                name: "CancelBy",
                table: "Withdraw");

            migrationBuilder.DropColumn(
                name: "CancelDate",
                table: "Withdraw");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "OutStockSessionPackage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcceptBy",
                table: "Withdraw",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptDate",
                table: "Withdraw",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancelBy",
                table: "Withdraw",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelDate",
                table: "Withdraw",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "OutStockSessionPackage",
                type: "float",
                nullable: true);
        }
    }
}
