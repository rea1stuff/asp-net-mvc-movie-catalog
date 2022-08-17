using MovieCatalog.Application.Users.Dtos;

namespace MovieCatalog.Application.Users;

public interface IUserService
{
    public void Register(RegistrationDto registrationDto);
    public void Login(LoginDto loginDto);
    public void Logout();
}