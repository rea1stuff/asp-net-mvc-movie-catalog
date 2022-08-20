using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.Web.Controllers;

public class UserController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Logout()
    {
        return RedirectToAction("Index", "Home");
    }
}