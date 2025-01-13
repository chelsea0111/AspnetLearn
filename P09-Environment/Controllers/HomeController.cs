using Microsoft.AspNetCore.Mvc;

namespace P09_Environment.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}