using Microsoft.AspNetCore.Mvc;

namespace P10_Configuration.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.MyKey1 = _configuration["MyKey"];
        ViewBag.MyKey2 = _configuration.GetValue<string>("x", "default");
        return View();
    }
}