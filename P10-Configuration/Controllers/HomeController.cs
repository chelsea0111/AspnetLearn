using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace P10_Configuration.Controllers;

public class HomeController : Controller
{
    private readonly WeatherApiOptions _options;

    public HomeController(IOptions<WeatherApiOptions> weatherApiOptions)
    {
        _options = weatherApiOptions.Value;
    }

    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.ClientID = _options.ClientID;
        ViewBag.ClientSecret = _options.ClientSecret;

        return View();
    }
}