namespace MovieCatalog.Application.Exceptions;

public class NotAllowedException: Exception
{
    public NotAllowedException(string msg = "Forbidden") : base(msg)
    {
        
    }
}