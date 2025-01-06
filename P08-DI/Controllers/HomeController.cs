using Microsoft.AspNetCore.Mvc;
using P08_ServiceContracts;
using P08_Services;

namespace P08_DI.Controllers;

public class HomeController : Controller
{
    private readonly ICitiesService _citiesService1;
    private readonly ICitiesService _citiesService2;
    private readonly ICitiesService _citiesService3;

    public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3)
    {
        _citiesService1 = citiesService1; // new CitiesService()
        _citiesService2 = citiesService2; // new CitiesService()
        _citiesService3 = citiesService3; // new CitiesService()
    }

    [Route("/")]
    public IActionResult Index()
    {
        Console.WriteLine(_citiesService1.ServiceInstanceId);
        Console.WriteLine(_citiesService2.ServiceInstanceId);
        Console.WriteLine(_citiesService3.ServiceInstanceId);
        List<string> cities = _citiesService1.GetCities();
        return View(cities);
    }
}