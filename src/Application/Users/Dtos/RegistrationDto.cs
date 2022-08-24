namespace MovieCatalog.Application.Users.Dtos;

public class RegistrationDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}