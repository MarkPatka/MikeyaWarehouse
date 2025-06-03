using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikeyaWarehouse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InStockFieldToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InStock",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Products");
        }
    }
}
