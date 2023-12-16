using MauiCodeChallenge.Core.Services;
using MauiCodeChallenge.View;
using MauiCodeChallenge.Core.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiCodeChallenge
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<CoffeePage>();
            builder.Services.AddTransient<CoffeeDetailPage>();
            builder.Services.AddSingleton<ICoffeeService, CoffeeService>();
            builder.Services.AddTransient<CoffeeViewModel>();

            return builder.Build();
        }
    }
}
