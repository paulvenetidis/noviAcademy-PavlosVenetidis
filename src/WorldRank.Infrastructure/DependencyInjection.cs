using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorldRank.Application.Interfaces;
using WorldRank.Infrastructure.Data;
using WorldRank.Infrastructure.Repositories;

namespace WorldRank.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // Ο DbContext, ρυθμισμένος για SQL Server με το connection string.
        services.AddDbContext<WorldRankDbContext>(options =>
            options.UseSqlServer(connectionString));

        // ---- Database-backed (ενεργό) ----
        services.AddScoped<IPlayerRepository, DBPlayerRepository>();
        services.AddScoped<IWalletRepository, DBWalletRepository>();

        // ---- In-memory (εναλλακτικό) ----
        // services.AddSingleton<IPlayerRepository, InMemoryPlayerRepository>();
        // services.AddSingleton<IWalletRepository, InMemoryWalletRepository>();

        return services;
    }
}
