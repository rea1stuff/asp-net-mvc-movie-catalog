using Microsoft.EntityFrameworkCore;
using MovieCatalog.Domain.Entities;

namespace MovieCatalog.Infrastructure.MovieCatalog;

public class MovieCatalogContext : DbContext
{
    public MovieCatalogContext(DbContextOptions<MovieCatalogContext> options)
        : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
}