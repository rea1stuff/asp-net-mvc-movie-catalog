using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.Application.Users;
using MovieCatalog.Application.Users.Dtos;
using MovieCatalog.Application.Validation;

namespace MovieCatalog.Application;

public static class Dependencies
{
    public static void AddApplication(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        
        services.AddFluentValidationClientsideAdapters();
        
        services.AddValidatorsFromAssemblyContaining<RegistrationValidation>();
    }
}