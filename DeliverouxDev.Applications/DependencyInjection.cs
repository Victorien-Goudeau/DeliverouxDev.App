using DeliverouxDev.Applications.UseCase.Login;
using Microsoft.Extensions.DependencyInjection;

namespace DeliverouxDev.Applications;

public static class DependencyInjection {
    public static void AddUseCase(this IServiceCollection services) {

        services.AddScoped<QueryLoginHandler>();
    }
}