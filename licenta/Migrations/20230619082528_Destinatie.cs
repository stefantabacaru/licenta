using Microsoft.EntityFrameworkCore.Migrations;

namespace licenta.Migrations
{
    public partial class Destinatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteDeparture",
                table: "Routes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RouteDestination",
                table: "Routes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteDeparture",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RouteDestination",
                table: "Routes");
        }
    }
}
