using System.Security.Claims;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Constants;
using MovieCatalog.Application.Movies;
using MovieCatalog.Application.Movies.Dtos;
using MovieCatalog.Application.Movies.ViewModels;

namespace MovieCatalog.Web.Controllers;

public class MovieController : ControllerBase
{
    private readonly IValidator<MovieDto> _validator;
    private readonly IMovieService _movieService;

    public MovieController(IValidator<MovieDto> validator, IMovieService movieService)
    {
        _validator = validator;
        _movieService = movieService;
    }

    public async Task<IActionResult> Index(
        int pageNumber = 0, int itemsPerPage = PageInfoDefaults.ItemsPerPage)
    {
        var model = await _movieService.GetMoviesByPage(pageNumber, itemsPerPage);

        return View(model);
    }

    public async Task<IActionResult> Details(int movieId)
    {
        var model = await _movieService.GetMovieById(movieId);

        return View(model);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(MovieDto model)
    {
        if (model.ImageFile is null)
        {
            ModelState.AddModelError("ImageFile", "The ImageFile field is required.");
            return View(model);
        }
        
        var result = await _validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, null);
            return View(model);
        }

        await _movieService.CreateMovie(
            model, UserId);

        return RedirectToAction("Index", "Movie");
    }

    [Authorize]
    public async Task<IActionResult> Edit(int movieId)
    {
        var model = await _movieService.GetMovieById(movieId);

        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Edit(MovieDto model)
    {
        var result = await _validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, null);
            return View(model);
        }

        await _movieService.Edit(model, UserId);

        return RedirectToAction("Index", "Movie");
    }

    [Authorize]
    public async Task<IActionResult> Remove(int movieId)
    {
        await _movieService.Remove(movieId, UserId);

        return RedirectToAction("Index", "Movie");
    }
}