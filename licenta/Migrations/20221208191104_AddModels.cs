using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace licenta.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturingDate = table.Column<DateTime>(nullable: false),
                    CarType = table.Column<string>(nullable: false),
                    SeatsNumber = table.Column<int>(nullable: false),
                    NumberPlate = table.Column<string>(nullable: false),
                    KmNumber = table.Column<int>(nullable: false),
                    CarHistory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Money = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerRouteId = table.Column<int>(nullable: false),
                    CustomerPhoneNumber = table.Column<string>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    WorkedDaysPerMonth = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: false),
                    CarToBeRepairedId = table.Column<int>(nullable: false),
                    EmployeeResponsibleId = table.Column<int>(nullable: false),
                    Problem = table.Column<string>(nullable: true),
                    RepairCost = table.Column<int>(nullable: false),
                    RepairDuration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
                    table.ForeignKey(
                        name: "FK_Repairs_Cars_CarToBeRepairedId",
                        column: x => x.CarToBeRepairedId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Employees_EmployeeResponsibleId",
                        column: x => x.EmployeeResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteEmployeeEmployeeId = table.Column<int>(nullable: true),
                    RouteCarId = table.Column<int>(nullable: false),
                    RouteDetails = table.Column<string>(nullable: true),
                    RoutePeriod = table.Column<DateTime>(nullable: false),
                    CollectedMoney = table.Column<string>(nullable: true),
                    SpentMoney = table.Column<string>(nullable: true),
                    KmNumber = table.Column<int>(nullable: false),
                    PassengersNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Routes_Cars_RouteCarId",
                        column: x => x.RouteCarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Employees_RouteEmployeeEmployeeId",
                        column: x => x.RouteEmployeeEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarsRoutes",
                columns: table => new
                {
                    CarsId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
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
                    EmployeeId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
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
                name: "IX_CarsRoutes_CarsId",
                table: "CarsRoutes",
                column: "CarsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoutes_RouteId",
                table: "EmployeeRoutes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CarToBeRepairedId",
                table: "Repairs",
                column: "CarToBeRepairedId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_EmployeeResponsibleId",
                table: "Repairs",
                column: "EmployeeResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteCarId",
                table: "Routes",
                column: "RouteCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteEmployeeEmployeeId",
                table: "Routes",
                column: "RouteEmployeeEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsRoutes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EmployeeRoutes");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
