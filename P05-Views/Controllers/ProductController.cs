using Microsoft.AspNetCore.Mvc;

namespace P05_Views.Controllers;

public class ProductController : Controller
{
    [Route("all")]
    public IActionResult All()
    {
        return View();
    }
}