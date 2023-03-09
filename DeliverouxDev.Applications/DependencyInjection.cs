using DeliverouxDev.Applications.UseCase.Login;
using Microsoft.Extensions.DependencyInjection;

namespace DeliverouxDev.Applications;

using UseCase.Account;
using UseCase.Commands;

public static class DependencyInjection {
    public static void AddUseCase(this IServiceCollection services) {

        services.AddScoped<QueryLoginHandler>();
        services.AddScoped<CommandDeleteUserAsyncHandler>();
        services.AddScoped<CommandUpdateUserAsyncHandler>();
        services.AddScoped<QueryGetAllUserHandler>();
        services.AddScoped<QueryGetStatsCommandsUseCase>();
    }
}