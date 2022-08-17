using Microsoft.AspNetCore.Identity;

namespace MovieCatalog.Application.Exceptions;

public class IdentityErrorException : Exception
{
    public IEnumerable<IdentityError> Errors { get; }

    public IdentityErrorException(IEnumerable<IdentityError> errors) 
        : base("Identity exception")
    {
        Errors = errors;
    }
}