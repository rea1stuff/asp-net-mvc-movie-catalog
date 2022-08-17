using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Users.Dtos;
using MovieCatalog.Domain.Entities;
using MovieCatalog.Domain.Interfaces.Repositories;

namespace MovieCatalog.Application.Users;

public class UserService : IUserService
{
    private readonly IUserIdentityService _userIdentityService;
    private readonly IMovieCatalogRepository<User> _movieCatalogRepository;

    public UserService(
        IUserIdentityService userIdentityService, 
        IMovieCatalogRepository<User> movieCatalogRepository)
    {
        _userIdentityService = userIdentityService;
        _movieCatalogRepository = movieCatalogRepository;
    }

    public void Register(RegistrationDto registrationDto)
    {
        string uId = Guid.NewGuid().ToString();

        _userIdentityService.Register(registrationDto, uId);
        _movieCatalogRepository.AddAsync(new User(uId));
    }

    public void Login(LoginDto loginDto)
    {
        _userIdentityService.Login(loginDto);
    }

    public void Logout()
    {
        _userIdentityService.Logout();
    }
}