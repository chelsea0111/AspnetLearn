using Microsoft.AspNetCore.Mvc;

namespace P08_DI.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}