using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Users.Dtos;
using MovieCatalog.Domain.Entities;
using MovieCatalog.Domain.Interfaces.Repositories;

namespace MovieCatalog.Application.Users;

public class UserService : IUserService
{
    private readonly IUserIdentityService _userIdentityService;
    private readonly IMovieCatalogRepository<User> _userRepository;

    public UserService(
        IUserIdentityService userIdentityService, 
        IMovieCatalogRepository<User> userRepository)
    {
        _userIdentityService = userIdentityService;
        _userRepository = userRepository;
    }

    public async Task Register(RegistrationDto registrationDto)
    {
        string uId = Guid.NewGuid().ToString();
        
        await _userIdentityService.Register(registrationDto, uId);
        await _userRepository.AddAsync(new User(uId));
    }

    public async Task Login(LoginDto loginDto)
    {
        await _userIdentityService.Login(loginDto);
    }

    public async Task Logout()
    {
        await _userIdentityService.Logout();
    }
}