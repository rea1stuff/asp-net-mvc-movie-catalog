using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.Application.Users.Dtos;

public class LoginDto
{
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}