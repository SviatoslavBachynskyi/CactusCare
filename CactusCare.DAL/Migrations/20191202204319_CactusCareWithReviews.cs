using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CactusCare.DAL.Migrations
{
    public partial class CactusCareWithReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Review",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "DoctorId", "Time" },
                values: new object[] { 1, "Чудовий лікар!", 1, new DateTime(2019, 12, 2, 22, 43, 19, 58, DateTimeKind.Local).AddTicks(1391) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "DoctorId", "Time" },
                values: new object[] { 2, "Погоджуюсь. Неймовірний лікар.", 1, new DateTime(2019, 12, 2, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "DoctorId", "Time" },
                values: new object[] { 3, "Жахливий лікар!", 2, new DateTime(2019, 12, 2, 22, 43, 19, 60, DateTimeKind.Local).AddTicks(8554) });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
