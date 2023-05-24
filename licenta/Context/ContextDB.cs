using licenta.DAOModels;
using Microsoft.EntityFrameworkCore;

namespace licenta.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyDao>()
                .HasMany<EmployeeDao>(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeDao>()
            .HasMany<RepairsDao>(e => e.Repairs)
            .WithOne(r => r.EmployeeResponsible)
            .HasForeignKey(e => e.EmployeeResponsibleId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeRouteDao>()
                .HasKey(er => new { er.EmployeeId, er.RouteId });

            modelBuilder.Entity<EmployeeDao>()
                .HasMany(e => e.EmployeeRoutes)
                .WithOne(er => er.Employee)
                .HasForeignKey(er => er.EmployeeId);

            modelBuilder.Entity<RoutesDao>()
                .HasMany(r => r.EmployeeRoutes)
                .WithOne(er => er.Route)
                .HasForeignKey(er => er.RouteId);

            modelBuilder.Entity<RoutesDao>()
            .HasMany(r => r.Passengers)
            .WithOne(er => er.CustomerRoute)
            .HasForeignKey(er => er.CustomerRouteId);

            modelBuilder.Entity<CarsRouteDao>()
                .HasKey(cr => new { cr.RouteId, cr.CarsId });

            modelBuilder.Entity<CarsDao>()
                .HasMany(c => c.CarsRoutes)
                .WithOne(cr => cr.Car)
                .HasForeignKey(cr => cr.CarsId);

            modelBuilder.Entity<RoutesDao>()
                .HasMany(r => r.CarsRoutes)
                .WithOne(cr => cr.Route)
                .HasForeignKey(cr => cr.RouteId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<EmployeeDao> Employees { get; set; }
        public DbSet<CarsDao> Cars { get; set; }
        public DbSet<CarsRouteDao> CarsRoutes { get; set; }
        public DbSet<CompanyDao> Company { get; set; }
        public DbSet<CustomerDao> Customers { get; set; }
        public DbSet<EmployeeRouteDao> EmployeeRoutes { get; set; }
        public DbSet<RepairsDao> Repairs { get; set; }
        public DbSet<RoutesDao> Routes { get; set; }
    }
}
