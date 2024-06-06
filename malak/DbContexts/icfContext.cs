using malak.Entities;
using Microsoft.EntityFrameworkCore;

namespace malak.DbContexts
{
    public class icfContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public icfContext(IConfiguration configuration)
        {

            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Centre> centres { get; set; } 
        public DbSet<Cour> cours { get; set; } 

        public DbSet<Prof> profs { get; set; } 

        public DbSet<Student> students { get; set; } 
        public DbSet<Admin> Admins { get; set; } 
    }
}
