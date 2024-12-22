using Microsoft.AspNetCore.Mvc;

namespace P03_Controllers.Controllers;

public class HomeController
{
    // 3. attribute routing
    [Route("sayhello")]
    public string method1()
    {
        return "Hello from method!";
    }
}