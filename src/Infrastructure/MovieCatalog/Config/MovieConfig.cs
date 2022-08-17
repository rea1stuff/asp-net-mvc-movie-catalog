using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCatalog.Domain.Entities;

namespace MovieCatalog.Infrastructure.MovieCatalog.Config;

public class MovieConfig : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.OwnsOne(
            m => m.Director,
            d =>
            {
                d.WithOwner();
            });
        builder.OwnsOne(
            m => m.ReleaseYear,
            r =>
            {
                r.WithOwner();
            });
    }
}