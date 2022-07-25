using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreWebAPI.Data.Migrations
{
    public partial class AddBallanceToCustommer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");
        }
    }
}
