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

        // WeatherApiOptions? weatherApiOptions = _configuration.GetSection("WeatherApi").Get<WeatherApiOptions>();
        // ViewBag.ClientID = weatherApiOptions.ClientID;
        // ViewBag.ClientSecret = weatherApiOptions.ClientSecret;

        WeatherApiOptions options = new WeatherApiOptions();
        IConfigurationSection confSection = _configuration.GetSection("WeatherApi");

        // Loads conf values into a new Options object
        confSection.Bind(options);
        ViewBag.ClientID = options.ClientID;
        ViewBag.ClientSecret = options.ClientSecret;

        return View();
    }
}