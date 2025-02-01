using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHive.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnDiscountPriceToBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountPrice",
                table: "Books",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Books");
        }
    }
}
