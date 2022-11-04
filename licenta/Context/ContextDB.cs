using Microsoft.EntityFrameworkCore;
using steptrans.DAOModels.Employee;
using steptrans.Models.Employee;

namespace steptrans.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<EmployeeDao> Employees { get; set; }
    }
}
