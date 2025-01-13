using Autofac;
using Microsoft.AspNetCore.Mvc;
using P08_ServiceContracts;
using P08_Services;

namespace P08_DI.Controllers;

public class HomeController : Controller
{
    private readonly ICitiesService _citiesService;

    // private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILifetimeScope _lifetimeScope;

    public HomeController(ICitiesService citiesService, ICitiesService citiesService2, ICitiesService citiesService3,
        ILifetimeScope lifetimeScope)
    {
        _citiesService = citiesService; // new CitiesService()
        _lifetimeScope = lifetimeScope;
    }

    [Route("/")]
    public IActionResult Index()
    {
        Console.WriteLine(_citiesService.ServiceInstanceId);

        // at the end of using block, it will automatically call Dispose() method
        // for all the services injected as a part of this scope.
        using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
        {
            // inject CitiesService here
            ICitiesService citiesService = scope.Resolve<ICitiesService>();
            Console.WriteLine(citiesService.ServiceInstanceId);
            // db work
            Console.WriteLine("db...working...");
        } // it calls CitiesService.Dispose() 

        List<string> cities = _citiesService.GetCities();
        return View(cities);
    }
}