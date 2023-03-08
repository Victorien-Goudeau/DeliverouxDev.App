using DeliverouxDev.Applications.Interfaces;
using DeliverouxDev.Infrastructures.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DeliverouxDev.Infrastructures;

public static class DependencyInjection
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IConnexionRepository, ConnexionRepository>();
    }
}