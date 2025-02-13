using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpiritCafe.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedOrederDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
