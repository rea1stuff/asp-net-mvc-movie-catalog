using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.Application.Users.Dtos;

public class RegistrationDto
{
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}