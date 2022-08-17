using Ardalis.GuardClauses;

namespace MovieCatalog.Domain.Entities.ValueObjects;

public class Director
{
    public Director(string name)
    {
        Guard.Against.NullOrEmpty(name);

        Name = name;
    }
    
    public string Name { get; }
}