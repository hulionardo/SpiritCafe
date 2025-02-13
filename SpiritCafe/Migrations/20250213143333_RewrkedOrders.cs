using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpiritCafe.Migrations
{
    /// <inheritdoc />
    public partial class RewrkedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "DishId", "OrderId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "DishId", "OrderId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCompletionTime",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCompletionTime",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CookId", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "DishId", "OrderId", "Id", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 4.8m },
                    { 2, 2, 2, 1.8m }
                });
        }
    }
}
