using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets.Migrations
{
    /// <inheritdoc />
    public partial class Addoptionaladdresscolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2024, 8, 31, 13, 39, 17, 691, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2024, 8, 31, 13, 39, 17, 691, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2024, 8, 31, 13, 39, 17, 691, DateTimeKind.Local).AddTicks(9038));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Owners");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2024, 8, 31, 13, 34, 41, 23, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2024, 8, 31, 13, 34, 41, 23, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2024, 8, 31, 13, 34, 41, 23, DateTimeKind.Local).AddTicks(753));
        }
    }
}
