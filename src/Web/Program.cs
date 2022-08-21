
var builder = WebApplication.CreateBuilder(args);

ConfigureServices();

var app = builder.Build();

ConfigureMiddlewares();

app.Run();



void ConfigureServices()
{
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
    MovieCatalog.Application.Dependencies.AddApplication(builder.Services);
    MovieCatalog.Infrastructure.Dependencies.AddInfrastructure(builder.Services);
}

void ConfigureMiddlewares()
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}