
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class SalonContext : DbContext
  {
    // public virtual DbSet<Cuisine> Cuisines { get; set; }
    // public DbSet<Restaurant> Restaurants { get; set; }

    public SalonContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}