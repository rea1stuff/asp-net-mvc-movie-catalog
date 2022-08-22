using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MovieCatalog.Domain.Entities;

namespace MovieCatalog.Application.Movies.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string ImagePath { get; set; }
    public User User { get; set; }
}