using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Domain.Interfaces.Repositories;
using MovieCatalog.Infrastructure.Identity;
using MovieCatalog.Infrastructure.MovieCatalog;
using MovieCatalog.Infrastructure.Services;

namespace MovieCatalog.Infrastructure;

public static class Dependencies
{
    public static void AddInfrastructure(
        IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<MovieCatalogContext>(c =>
            c.UseNpgsql(configuration.GetConnectionString("MovieCatalogConnection")));
        
        services.AddDbContext<IdentityDbContext>(options =>
            options.UseNpgsql(configuration["IdentityDbConnection"]));
        
        services.AddScoped<IUserIdentityService, UserIdentityService>();
        services.AddScoped(
            typeof(IMovieCatalogRepository<>), 
            typeof(MovieCatalogRepository<>));

        services.AddIdentity<UserIdentity, IdentityRole>()
            .AddEntityFrameworkStores<IdentityDbContext>();
    }
}