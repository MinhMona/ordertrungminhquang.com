using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NhapHangV2.AppDbContext.Migrations
{
    public partial class Update21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTypeId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: true),
                    SideBar = table.Column<bool>(type: "bit", nullable: true),
                    IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGFacebookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGFacebookDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGFacebookIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGTwitterTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGTwitterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OGTwitterIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NodeId = table.Column<int>(type: "int", nullable: true),
                    NodeAliasPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MetaKeyword = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NodeAliasPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NodeId = table.Column<int>(type: "int", nullable: true),
                    OGDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGFacebookDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGFacebookIMG = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGFacebookTitle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGImage = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGTitle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGTwitterDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGTwitterIMG = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGTwitterTitle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OGUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PageContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageTypeId = table.Column<int>(type: "int", nullable: true),
                    SideBar = table.Column<bool>(type: "bit", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });
        }
    }
}
