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

            modelBuilder.Entity<EmployeeDao>()
                .HasMany(e => e.EmployeeRoutes)
                .WithOne(er => er.RouteEmployee)
                .HasForeignKey(er => er.EmployeeId);

            modelBuilder.Entity<RoutesDao>()
            .HasMany(r => r.Passengers)
            .WithOne(er => er.CustomerRoute)
            .HasForeignKey(er => er.CustomerRouteId);

            modelBuilder.Entity<CarsDao>()
                .HasMany(c => c.CarsRoutes)
                .WithOne(cr => cr.RouteCar)
                .HasForeignKey(cr => cr.CarId);
        }

        public DbSet<EmployeeDao> Employees { get; set; }
        public DbSet<CarsDao> Cars { get; set; }
        public DbSet<CompanyDao> Company { get; set; }
        public DbSet<CustomerDao> Customers { get; set; }
        public DbSet<RepairsDao> Repairs { get; set; }
        public DbSet<RoutesDao> Routes { get; set; }
    }
}
