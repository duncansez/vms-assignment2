using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using VMS.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VMS.Models
{
    public class VMSDbContext : DbContext
    {
        public string _user;

        public VMSDbContext() : base()
        {

        }
        public VMSDbContext(DbContextOptions<VMSDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ModelsSetting.GetConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
