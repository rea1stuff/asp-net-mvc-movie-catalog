using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.Application.Users;

namespace MovieCatalog.Application;

public static class Dependencies
{
    public static void AddApplication(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}