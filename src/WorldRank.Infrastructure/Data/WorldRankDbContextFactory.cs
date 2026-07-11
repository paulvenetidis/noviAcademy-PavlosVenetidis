using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WorldRank.Infrastructure.Data;

// Χρησιμοποιείται ΜΟΝΟ από τα EF migration tools (design-time).
// Δίνει στα tools έναν έτοιμο DbContext, χωρίς να χρειάζεται το DI του Program.cs.
public class WorldRankDbContextFactory : IDesignTimeDbContextFactory<WorldRankDbContext>
{
    public WorldRankDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WorldRankDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=NoviAcademy;Trusted_Connection=True;TrustServerCertificate=True;");

        return new WorldRankDbContext(optionsBuilder.Options);
    }
}