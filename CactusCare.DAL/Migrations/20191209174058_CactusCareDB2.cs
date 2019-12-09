using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CactusCare.DAL.Migrations
{
    public partial class CactusCareDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 40, 58, 400, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 40, 58, 404, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 40, 58, 405, DateTimeKind.Local).AddTicks(63));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 35, 16, 415, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 35, 16, 420, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 35, 16, 420, DateTimeKind.Local).AddTicks(1554));
        }
    }
}
