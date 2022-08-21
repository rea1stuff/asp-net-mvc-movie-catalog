using System.Security.Claims;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Movies;
using MovieCatalog.Application.Movies.Dtos;

namespace MovieCatalog.Web.Controllers;

public class MovieController : Controller
{
    private readonly IValidator<MovieDto> _validator;
    private readonly IMovieService _movieService;
    private readonly string _uId;

    public MovieController(IValidator<MovieDto> validator, IMovieService movieService)
    {
        _validator = validator;
        _movieService = movieService;
        
        _uId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(MovieDto model)
    {
        var result = await _validator.ValidateAsync(model);
        
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, null);
            return View(model);
        }

        await _movieService.CreateMovie(
            model, _uId);
        
        return RedirectToAction("Index", "Movie");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Edit(MovieDto model, int movieId)
    {
        await _movieService.Edit(model, movieId, _uId);
        
        return RedirectToAction("Index", "Movie");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Remove(int movieId)
    {
        await _movieService.Remove(movieId, _uId);
        
        return RedirectToAction("Index", "Movie");
    }
}