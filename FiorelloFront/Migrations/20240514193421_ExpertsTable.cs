using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFront.Migrations
{
    public partial class ExpertsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 14, 23, 34, 21, 591, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 14, 23, 34, 21, 591, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 14, 23, 34, 21, 591, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "CreateDate", "Image", "IsDeleted", "Name", "Position" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 14, 23, 34, 21, 591, DateTimeKind.Local).AddTicks(6750), "h3-team-img-1.png", false, "CRYSTAL BROOKS", "Florist" },
                    { 2, new DateTime(2024, 5, 14, 23, 34, 21, 591, DateTimeKind.Local).AddTicks(6750), "h3-team-img-2.png", false, "SHIRLEY HARRIS", "Manager" },
                    { 3, new DateTime(2024, 5, 14, 23, 34, 21, 591, DateTimeKind.Local).AddTicks(6750), "h3-team-img-3.png", false, "BEVERLY CLARK", "Florist" },
                    { 4, new DateTime(2024, 5, 14, 23, 34, 21, 591, DateTimeKind.Local).AddTicks(6750), "h3-team-img-4.png", false, "AMANDA WATKINS", "Florist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 14, 23, 3, 12, 49, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 14, 23, 3, 12, 49, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 14, 23, 3, 12, 49, DateTimeKind.Local).AddTicks(2140));
        }
    }
}
