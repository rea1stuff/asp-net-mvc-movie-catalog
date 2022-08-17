namespace MovieCatalog.Application.Users;

public interface IUserService
{
    public void Register();
    public void Login();
    public void Logout();
}