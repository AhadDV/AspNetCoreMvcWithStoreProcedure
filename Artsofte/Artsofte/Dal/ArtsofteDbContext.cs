using Artsofte.Configuration;
using Artsofte.Models;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.Dal
{
    public class ArtsofteDbContext:DbContext
    {
        public ArtsofteDbContext(DbContextOptions<ArtsofteDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<EmployeeDataFromDb> EmployeeDatasFromDb { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmlployeDataFromDboConf());
       
            base.OnModelCreating(modelBuilder);
        }


    }
}
