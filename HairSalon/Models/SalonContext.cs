using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class SalonContext : DbContext
  {
    // public virtual DbSet<Client> Clients { get; set; }
    public DbSet<Stylist> Stylists { get; set; }

    public SalonContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
