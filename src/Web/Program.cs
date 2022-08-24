using Microsoft.EntityFrameworkCore;
using MovieCatalog.Infrastructure.Identity;
using MovieCatalog.Infrastructure.MovieCatalog;
using MovieCatalog.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var scopedProvider = scope.ServiceProvider;

ApplyMigrations();

SeedDb();

ConfigureMiddlewares();

app.Run();



void ConfigureServices()
{
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
    MovieCatalog.Application.Dependencies.AddApplication(builder.Services);
    MovieCatalog.Infrastructure.Dependencies.AddInfrastructure(builder.Services);
    builder.Services.AddScoped<DbFakeDataSeeder>();
}

void ConfigureMiddlewares()
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseExceptionHandler("/Error/Index");
    
    app.UseHsts();
    app.UseHttpsRedirection();
    
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    
    app.UseStaticFiles();
    
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Movie}/{action=Index}/{id?}");
}

void ApplyMigrations()
{
    app.Logger.LogInformation("Applying migrations...");
    
    try
    {
        var catalogContext = scopedProvider.GetRequiredService<MovieCatalogContext>();
        catalogContext.Database.Migrate();
        
        var identityDb = scopedProvider.GetRequiredService<IdentityDbContext>();
        identityDb.Database.Migrate();
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred applying migrations");
    }
}

void SeedDb()
{
    var fakeDataSeeder = scopedProvider.GetRequiredService<DbFakeDataSeeder>();
    fakeDataSeeder.Seed();
}