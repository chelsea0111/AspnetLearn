using Microsoft.AspNetCore.Mvc;

namespace P05_Views.Controllers;

[Controller]
public class HomeController : Controller
{
    [Route("home")]
    [Route("/")]
    public IActionResult Index()
    {
        // return View("abc"); // view name is: abc.cshtml

        // default view name is: Index.cshtml
        // the view is searched and expected to be in the 'Views/Home/Index.cshtml'
        return View();
    }
}