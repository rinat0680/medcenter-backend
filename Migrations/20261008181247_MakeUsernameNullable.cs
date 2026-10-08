using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalCenterApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeUsernameNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 50000.00m);

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 120000.00m);

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 20000.00m);

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "Id", "Description", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 4, "Услуга мед организации. Тут подробное описание услуги и дополнительная информация", new TimeSpan(0, 3, 30, 0, 0), "Четвертая услуга", 920000.00m },
                    { 5, "Услуга мед организации. Тут подробное описание услуги и дополнительная информация", new TimeSpan(0, 3, 0, 0, 0), "Удаление чего-то", 320000.00m },
                    { 6, "Услуга мед организации. Тут подробное описание услуги и дополнительная информация", new TimeSpan(0, 2, 10, 0, 0), "Увеличение чего-то", 201000.00m },
                    { 7, "Услуга мед организации. Тут подробное описание услуги и дополнительная информация", new TimeSpan(0, 1, 40, 0, 0), "Очистка и профилактика чего-то", 210000.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 50.00m);

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 120.00m);

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 20.00m);
        }
    }
}
