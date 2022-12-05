using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WeightTo",
                table: "WarehouseFee",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WeightFrom",
                table: "WarehouseFee",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FeeTQVNPerWeight",
                table: "Users",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FeeWeightPerKg",
                table: "TransportationOrder",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "SmallPackage",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "OrderTemp",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Order",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TQVNWeight",
                table: "MainOrder",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderWeight",
                table: "MainOrder",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WeightTo",
                table: "InWareHousePrice",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WeightFrom",
                table: "InWareHousePrice",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "BigPackage",
                type: "decimal(18,1)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WeightTo",
                table: "WarehouseFee",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WeightFrom",
                table: "WarehouseFee",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FeeTQVNPerWeight",
                table: "Users",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FeeWeightPerKg",
                table: "TransportationOrder",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "SmallPackage",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "OrderTemp",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Order",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TQVNWeight",
                table: "MainOrder",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderWeight",
                table: "MainOrder",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WeightTo",
                table: "InWareHousePrice",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WeightFrom",
                table: "InWareHousePrice",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "BigPackage",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)",
                oldNullable: true);
        }
    }
}
