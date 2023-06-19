using Microsoft.EntityFrameworkCore.Migrations;

namespace licenta.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cars_RouteCarId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Employees_RouteEmployeeEmployeeId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "CarsRoutes");

            migrationBuilder.DropTable(
                name: "EmployeeRoutes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RouteCarId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RouteEmployeeEmployeeId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RouteCarId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RouteEmployeeEmployeeId",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Routes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Routes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CarId",
                table: "Routes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_EmployeeId",
                table: "Routes",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Employees_EmployeeId",
                table: "Routes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Employees_EmployeeId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_CarId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_EmployeeId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "RouteCarId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteEmployeeEmployeeId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarsRoutes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsRoutes", x => new { x.RouteId, x.CarsId });
                    table.ForeignKey(
                        name: "FK_CarsRoutes_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarsRoutes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoutes",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoutes", x => new { x.EmployeeId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_EmployeeRoutes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoutes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteCarId",
                table: "Routes",
                column: "RouteCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteEmployeeEmployeeId",
                table: "Routes",
                column: "RouteEmployeeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarsRoutes_CarsId",
                table: "CarsRoutes",
                column: "CarsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoutes_RouteId",
                table: "EmployeeRoutes",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cars_RouteCarId",
                table: "Routes",
                column: "RouteCarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Employees_RouteEmployeeEmployeeId",
                table: "Routes",
                column: "RouteEmployeeEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
