using Microsoft.AspNetCore.Mvc;

namespace P06_Layout_Views.Controllers;

public class ProductController : Controller
{
    [Route("products")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("search-product/{productId?}")]
    public IActionResult Search(int? productId)
    {
        ViewBag.ProductId = productId;
        return View();
    }

    [Route("order-product")]
    public IActionResult Order()
    {
        return View();
    }
}