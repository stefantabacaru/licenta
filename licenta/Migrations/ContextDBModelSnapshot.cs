// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using steptrans.Context;

namespace licenta.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("licenta.DAOModels.CarsDao", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KmNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatsNumber")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("licenta.DAOModels.CarsRouteDao", b =>
                {
                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("CarsId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("RouteId", "CarsId");

                    b.HasIndex("CarsId");

                    b.ToTable("CarsRoutes");
                });

            modelBuilder.Entity("licenta.DAOModels.CompanyDao", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Money")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("licenta.DAOModels.CustomerDao", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerRouteId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("licenta.DAOModels.EmployeeDao", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkedDaysPerMonth")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("licenta.DAOModels.EmployeeRouteDao", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("EmployeeId", "RouteId");

                    b.HasIndex("RouteId");

                    b.ToTable("EmployeeRoutes");
                });

            modelBuilder.Entity("licenta.DAOModels.RepairsDao", b =>
                {
                    b.Property<int>("RepairId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarToBeRepairedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeResponsibleId")
                        .HasColumnType("int");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Problem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepairCost")
                        .HasColumnType("int");

                    b.Property<int>("RepairDuration")
                        .HasColumnType("int");

                    b.HasKey("RepairId");

                    b.HasIndex("CarToBeRepairedId");

                    b.HasIndex("EmployeeResponsibleId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("licenta.DAOModels.RoutesDao", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollectedMoney")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KmNumber")
                        .HasColumnType("int");

                    b.Property<int>("PassengersNumber")
                        .HasColumnType("int");

                    b.Property<int>("RouteCarId")
                        .HasColumnType("int");

                    b.Property<string>("RouteDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RouteEmployeeEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RoutePeriod")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpentMoney")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteId");

                    b.HasIndex("RouteCarId");

                    b.HasIndex("RouteEmployeeEmployeeId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("licenta.DAOModels.CarsRouteDao", b =>
                {
                    b.HasOne("licenta.DAOModels.CarsDao", "Car")
                        .WithMany("CarsRoutes")
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("licenta.DAOModels.RoutesDao", "Route")
                        .WithMany("CarsRoutes")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("licenta.DAOModels.EmployeeDao", b =>
                {
                    b.HasOne("licenta.DAOModels.CompanyDao", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("licenta.DAOModels.EmployeeRouteDao", b =>
                {
                    b.HasOne("licenta.DAOModels.EmployeeDao", "Employee")
                        .WithMany("EmployeeRoutes")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("licenta.DAOModels.RoutesDao", "Route")
                        .WithMany("EmployeeRoutes")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("licenta.DAOModels.RepairsDao", b =>
                {
                    b.HasOne("licenta.DAOModels.CarsDao", "CarToBeRepaired")
                        .WithMany("Repairs")
                        .HasForeignKey("CarToBeRepairedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("licenta.DAOModels.EmployeeDao", "EmployeeResponsible")
                        .WithMany("Repairs")
                        .HasForeignKey("EmployeeResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("licenta.DAOModels.RoutesDao", b =>
                {
                    b.HasOne("licenta.DAOModels.CarsDao", "RouteCar")
                        .WithMany()
                        .HasForeignKey("RouteCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("licenta.DAOModels.EmployeeDao", "RouteEmployee")
                        .WithMany()
                        .HasForeignKey("RouteEmployeeEmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
