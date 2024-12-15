using FHS.Mobile.Interfaces;
using FHS.Mobile.Services;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace FHS.Mobile
{
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

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IApiService, ApiService>();
            builder.Services.AddScoped<INavigationService, NavigationService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
