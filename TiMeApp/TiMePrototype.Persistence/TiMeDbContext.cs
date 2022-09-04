using Microsoft.EntityFrameworkCore;
using TiMePrototype.Domain;
using TiMePrototype.Domain.Common;

namespace TiMePrototype.Persistence;

public class TiMeDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Shift>? Shifts { get; set; }

    public TiMeDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TiMeDbContext).Assembly);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        modelBuilder.Entity<Shift>()
            .Property(o => o.HourlyRate)
            .HasColumnType("decimal(18,2)");
    }
}
