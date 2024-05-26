using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFront.Migrations
{
    public partial class newTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreateDate", "IsDeleted", "Key", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6940), false, "HeaderLogo", "logo.png" },
                    { 2, new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6940), false, "Phone", "+994508802323" }
                });

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "CreateDate", "Icon", "IsDeleted", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6850), "<i class=\"fa-brands fa-twitter\"></i>", false, "Twitter", "https://twitter.com/home" },
                    { 2, new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6880), "<i class=\"fa-brands fa-instagram\"></i>", false, "Instagram", "https://www.instagram.com/" },
                    { 3, new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6890), "<i class=\"fa-brands fa-tumblr\"></i>", false, "Tumblr", "https://www.tumblr.com/" },
                    { 4, new DateTime(2024, 5, 21, 20, 9, 9, 369, DateTimeKind.Local).AddTicks(6890), "<i class=\"fa-brands fa-pinterest\"></i>", false, "Pinterest", "https://www.pinterest.com/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 21, 57, 14, 458, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 21, 57, 14, 458, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 21, 57, 14, 458, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 21, 57, 14, 458, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 21, 57, 14, 458, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 21, 57, 14, 458, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 15, 21, 57, 14, 458, DateTimeKind.Local).AddTicks(5120));
        }
    }
}
