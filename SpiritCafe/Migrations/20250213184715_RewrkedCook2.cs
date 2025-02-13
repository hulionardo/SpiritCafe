using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpiritCafe.Migrations
{
    /// <inheritdoc />
    public partial class RewrkedCook2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentWorkload",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Cooks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkload",
                table: "Cooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Cooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrentWorkload", "IsAvailable" },
                values: new object[] { 0, true });

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrentWorkload", "IsAvailable" },
                values: new object[] { 0, true });
        }
    }
}
