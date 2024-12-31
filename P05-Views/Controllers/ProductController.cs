using Microsoft.AspNetCore.Mvc;

namespace P05_Views.Controllers;

public class ProductController : Controller
{
    [Route("/product/all")]
    public IActionResult All()
    {
        // firstly - Views/Product/All.cshtml
        // then - Views/Shared/All.cshtml
        return View(); 
    }
}