using GrindTwo.Web.Components;
using GrindTwo.Shared.Services;
using GrindTwo.Web.Services;
using GrindTwo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the GrindTwo.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
        typeof(GrindTwo.Shared._Imports).Assembly);

var db = new AppDbContext();
await db.Database.MigrateAsync();
await db.DisposeAsync();

app.Run();
