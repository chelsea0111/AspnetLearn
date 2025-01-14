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

        // ViewBag.ClientID = _configuration["WeatherApi:ClientID"];
        // ViewBag.ClientSecret = _configuration.GetValue<string>("WeatherApi:ClientSecret", "default secret");

        WeatherApiOptions? weatherApiOptions = _configuration.GetSection("WeatherApi").Get<WeatherApiOptions>();
        ViewBag.ClientID = weatherApiOptions.ClientID;
        ViewBag.ClientSecret = weatherApiOptions.ClientSecret;

        return View();
    }
}