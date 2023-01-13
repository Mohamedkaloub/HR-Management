using city.Models;
using Microsoft.EntityFrameworkCore;

namespace city.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Management> Management { get; set; }
        public DbSet<RetReason> RetReason { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Advance> Advance { get; set; }
        public DbSet<Section> Sections { get; set; }    


    }
}
