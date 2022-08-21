using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.Application.Users.Dtos;

public class LoginDto
{
    [Required(ErrorMessage = "Поле обязательно")]
    [DataType(DataType.Text)]
    [StringLength(30, MinimumLength = 4, ErrorMessage = "От 4х до 30 символов")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно")]
    [DataType(DataType.Password)]
    [StringLength(30, MinimumLength = 4, ErrorMessage = "От 4х до 30 символов")]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}