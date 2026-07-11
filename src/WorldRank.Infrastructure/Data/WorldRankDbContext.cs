using Microsoft.EntityFrameworkCore;
using WorldRank.Domain.Entities;

namespace WorldRank.Infrastructure.Data;

public class WorldRankDbContext : DbContext
{
    public WorldRankDbContext(DbContextOptions<WorldRankDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players => Set<Player>();
    public DbSet<Wallet> Wallets => Set<Wallet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Player
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedNever();
        });

        // Wallet
        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(w => w.Id);
            entity.Property(w => w.Id).ValueGeneratedNever();
            entity.HasIndex(w => new { w.PlayerId, w.Currency }).IsUnique();
            entity.Property(w => w.Currency).HasConversion<string>();
            entity.Property(w => w.Balance).HasPrecision(18, 2);
        });
    }
}