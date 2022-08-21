using FluentValidation;
using MovieCatalog.Application.Users.Dtos;

namespace MovieCatalog.Application.Validation;

public class LoginValidation : AbstractValidator<LoginDto>
{
    public LoginValidation()
    {
        RuleFor(x => x.UserName).NotEmpty().Length(4, 30);
        RuleFor(x => x.Password).NotEmpty().Length(4, 30);
    }
}