namespace MovieCatalog.Application.Users.Dtos;

public class LoginDto
{
    public string Login { get; private set; }
    public string Password { get; private set; }
    public bool RememberMe { get; private set; }
}