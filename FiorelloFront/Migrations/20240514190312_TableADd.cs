using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFront.Migrations
{
    public partial class TableADd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreateDate", "Description", "Image", "IsDeleted", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 14, 23, 3, 12, 49, DateTimeKind.Local).AddTicks(2100), "Salam", "blog-feature-img-1.jpg", false, "Blog Ilgar" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreateDate", "Description", "Image", "IsDeleted", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 14, 23, 3, 12, 49, DateTimeKind.Local).AddTicks(2140), "Salam", "blog-feature-img-3.jpg", false, "Blog Kmaran" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreateDate", "Description", "Image", "IsDeleted", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 14, 23, 3, 12, 49, DateTimeKind.Local).AddTicks(2140), "Salam", "blog-feature-img-4.jpg", false, "Blog Orxan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
