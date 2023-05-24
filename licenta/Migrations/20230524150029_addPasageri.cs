using Microsoft.EntityFrameworkCore.Migrations;

namespace licenta.Migrations
{
    public partial class addPasageri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerRouteId",
                table: "Customers",
                column: "CustomerRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Routes_CustomerRouteId",
                table: "Customers",
                column: "CustomerRouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Routes_CustomerRouteId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerRouteId",
                table: "Customers");
        }
    }
}
