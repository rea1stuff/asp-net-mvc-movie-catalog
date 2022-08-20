using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}