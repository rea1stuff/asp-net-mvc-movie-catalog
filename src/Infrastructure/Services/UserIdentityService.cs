using Microsoft.AspNetCore.Identity;
using MovieCatalog.Application.Exceptions;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Users.Dtos;
using MovieCatalog.Infrastructure.Identity;

namespace MovieCatalog.Infrastructure.Services;

public class UserIdentityService : IUserIdentityService
{
    private readonly UserManager<UserIdentity> _userManager;
    private readonly SignInManager<UserIdentity> _signInManager;

    public UserIdentityService(
        UserManager<UserIdentity> userManager, 
        SignInManager<UserIdentity> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task Register(RegistrationDto registrationDto, string uId)
    {
        UserIdentity user = new()
        {
            Id = uId,
            UserName = registrationDto.UserName
        };
        
        var result = await _userManager.CreateAsync(user, registrationDto.Password);

        if (!result.Succeeded)
        {
            throw new IdentityErrorException(result.Errors);
        }

        await _signInManager.SignInAsync(user, true);
    }

    public async Task Login(LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(
            loginDto.UserName, 
            loginDto.Password, 
            loginDto.RememberMe, 
            false);

        if (!result.Succeeded)
        {
            throw new InvalidLoginException();
        }
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}