using Microsoft.AspNetCore.Mvc;

namespace P03_Controllers.Controllers;

public class HomeController : Controller
{
    // 3. attribute routing
    [Route("home")]
    [Route("/")]
    public ContentResult Index()
    {
        // return new ContentResult()
        // {
        //     Content = "Hello from home!~~~", ContentType = "text/plain"
        // };
        
        // to use this predefined method, the XxxController must inherit from the Controller parent class
        return Content("<h1>Hello from home!~~~!!!</h1> <h2>I'm h2</h2>", "text/html");
    }

    [Route("about")]
    public string About()
    {
        return "Hello from about!";
    }

    [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
    public string Contact()
    {
        return "Hello from contact!";
    }
}