using Microsoft.Extensions.Logging;
using GrindTwo.Shared.Services;
using GrindTwo.Services;
using GrindTwo.Data;
using Microsoft.EntityFrameworkCore;

namespace GrindTwo;

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

        // Add device-specific services used by the GrindTwo.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();
        builder.Services.AddDbContext<AppDbContext>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        var db = new AppDbContext();
        db.Database.Migrate();
        db.Dispose();

        return builder.Build();
    }
}
