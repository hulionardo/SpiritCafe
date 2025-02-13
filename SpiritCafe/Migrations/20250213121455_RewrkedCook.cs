using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpiritCafe.Migrations
{
    /// <inheritdoc />
    public partial class RewrkedCook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxWorkload",
                table: "Cooks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxWorkload",
                table: "Cooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxWorkload",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxWorkload",
                value: 5);
        }
    }
}
