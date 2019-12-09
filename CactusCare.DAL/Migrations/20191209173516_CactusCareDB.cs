using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CactusCare.DAL.Migrations
{
    public partial class CactusCareDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 31, 33, 775, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 31, 33, 780, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2019, 12, 9, 19, 31, 33, 780, DateTimeKind.Local).AddTicks(4909));
        }
    }
}
