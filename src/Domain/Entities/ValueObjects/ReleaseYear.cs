namespace MovieCatalog.Domain.Entities.ValueObjects;

public class ReleaseYear
{
    private ReleaseYear()
    {
        
    }
    public ReleaseYear(int year)
    {
        if (year < 1000)
        {
            throw new Exception("ReleaseYear is not valid");
        }
        
        Year = year;
    }
    public int Year { get; private set; }
}