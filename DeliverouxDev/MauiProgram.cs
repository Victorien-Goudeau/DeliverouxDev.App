using DeliverouxDev.Applications;
using DeliverouxDev.Authentication;
using Microsoft.Extensions.Logging;
using DeliverouxDev.Data;
using DeliverouxDev.Infrastructures;
using Microsoft.AspNetCore.Components.Authorization;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace DeliverouxDev;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddAuthorizationCore();
		builder.Services.AddUseCase();
		builder.Services.AddMediatR(typeof(Applications.DependencyInjection).Assembly);
		builder.Services.AddRepository();
		builder.Services.AddScoped<CustomAuthenticationStateProvider>();
		builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthenticationStateProvider>());
        builder.Services.AddMudServices();
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
