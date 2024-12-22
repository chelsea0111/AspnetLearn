using Microsoft.AspNetCore.Mvc;

namespace P03_Controllers.Controllers;

public class HomeController
{
    // 3. attribute routing
    [Route("home")]
    [Route("/")]
    public string Index()
    {
        return "Hello from home!";
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