using Microsoft.EntityFrameworkCore;
using WeightTracking.Models;

namespace WeightTracking
{
    public class WeightTrackerDbContext : DbContext
    {


        public WeightTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WeightEntry> WeightEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("your_connection_string_here");
        }
    }
}
