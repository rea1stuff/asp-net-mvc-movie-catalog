using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Exceptions;
using MovieCatalog.Application.Users;
using MovieCatalog.Application.Users.Dtos;

namespace MovieCatalog.Web.Controllers;

public class UserController : Controller
{
    private IValidator<RegistrationDto> _registerValidator;
    private IValidator<LoginDto> _loginValidator;
    private readonly IUserService _userService;

    public UserController(
        IUserService userService, 
        IValidator<RegistrationDto> registerValidator, 
        IValidator<LoginDto> loginValidator)
    {
        _userService = userService;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationDto model)
    {
        ValidationResult result = await _registerValidator.ValidateAsync(model);
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, null);
            
            return View(model);
        }

        try
        {
            await _userService.Register(model);
        }
        catch (IdentityErrorException e)
        {
            foreach (var error in e.Errors)
                ModelState.AddModelError(error.Code.Contains("Password") ? "Password" : "", error.Description);
            return View(model);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "Регистрация не успешна.");
            return View(model);
        }

        return RedirectToAction("Index", "Movie");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        ValidationResult result = await _loginValidator.ValidateAsync(model);
        
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, null);
            
            return View(model);
        }

        try
        {
            await _userService.Login(model);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
            return View(model);
        }
        
        return RedirectToAction("Index", "Movie");;
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        
        return RedirectToAction("Index", "Movie");
    }
}