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
    public static void AddInfrastructure(IServiceCollection services)
    {
        services.AddDbContext<MovieCatalogContext>(c =>
            c.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=test;Database=MovieDb"));
        
        services.AddDbContext<IdentityDbContext>(options =>
            options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=test;Database=IdentityDb"));
        
        services.AddScoped<IUserIdentityService, UserIdentityService>();
        services.AddScoped(
            typeof(IMovieCatalogRepository<>), 
            typeof(MovieCatalogRepository<>));

        services.AddIdentity<UserIdentity, IdentityRole>()
            .AddEntityFrameworkStores<IdentityDbContext>();
    }
}