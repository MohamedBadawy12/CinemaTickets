using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTickets.Migrations
{
    public partial class Order_and_OrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Triler",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Triler",
                table: "Movies");
        }
    }
}
