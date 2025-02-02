using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHive.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsPercentageAndDiscountToCouponsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Coupons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPercentage",
                table: "Coupons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "IsPercentage",
                table: "Coupons");
        }
    }
}
