using Microsoft.AspNetCore.Mvc;
using P08_Services;

namespace P08_DI.Controllers;

public class HomeController : Controller
{
    private readonly CitiesService _citiesService;

    public HomeController(CitiesService citiesService)
    {
        _citiesService = new CitiesService();
    }

    [Route("/")]
    public IActionResult Index()
    {
        List<string> cities = _citiesService.GetCities();
        return View(cities);
    }
}