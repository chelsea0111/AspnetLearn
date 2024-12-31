using Microsoft.AspNetCore.Mvc;

namespace P06_DI.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}