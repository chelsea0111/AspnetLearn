using Microsoft.AspNetCore.Mvc;

namespace P11_HttpClient.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}