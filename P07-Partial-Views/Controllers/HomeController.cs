using Microsoft.AspNetCore.Mvc;

namespace P07_Partial_Views.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        ViewData["ListTitle"] = "CitiesList";
        ViewData["ListItems"] = new List<string>()
        {
            "Paris",
            "New York",
            "Shanghai",
            "Tokyo",
            "London"
        };
        return View();
    }

    [Route("/about")]
    public IActionResult About()
    {
        return View();
    }
}