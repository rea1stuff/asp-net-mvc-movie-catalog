using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MovieCatalog.Application.Movies.Dtos;

public class MovieDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public IFormFile? Image { get; set; }
}