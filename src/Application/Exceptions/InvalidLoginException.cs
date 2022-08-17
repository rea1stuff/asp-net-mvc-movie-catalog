namespace MovieCatalog.Application.Exceptions;

public class InvalidLoginException : Exception
{
    public InvalidLoginException(string message = "Invalid login or password") : base(message)
    {
        
    }
}