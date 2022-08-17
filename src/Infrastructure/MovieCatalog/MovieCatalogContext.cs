using Microsoft.EntityFrameworkCore;
using MovieCatalog.Domain.Entities;
using MovieCatalog.Infrastructure.MovieCatalog.Config;

namespace MovieCatalog.Infrastructure.MovieCatalog;

public class MovieCatalogContext : DbContext
{
    public MovieCatalogContext(DbContextOptions<MovieCatalogContext> options)
        : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new MovieConfig());
    }
}