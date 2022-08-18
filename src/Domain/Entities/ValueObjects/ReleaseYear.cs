namespace MovieCatalog.Domain.Entities.ValueObjects;

public class ReleaseYear
{
    private ReleaseYear()
    {
        
    }
    public ReleaseYear(int year)
    {
        if (!Enumerable.Range(1000, DateTime.Now.Year).Contains(year))
        {
            throw new Exception("ReleaseYear is not valid");
        }
        
        Year = year;
    }
    public int Year { get; private set; }
}