using MovieCatalog.Application.Users.Dtos;

namespace MovieCatalog.Application.Users;

public interface IUserService
{
    public Task Register(RegistrationDto registrationDto);
    public Task Login(LoginDto loginDto);
    public Task Logout();
}