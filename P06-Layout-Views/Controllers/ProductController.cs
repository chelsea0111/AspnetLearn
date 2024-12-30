using Microsoft.AspNetCore.Mvc;

namespace P06_Layout_Views.Controllers;

public class ProductController : Controller
{
    [Route("products")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("search-product")]
    public IActionResult Search()
    {
        return View();
    }

    [Route("order-product")]
    public IActionResult Order()
    {
        return View();
    }
}