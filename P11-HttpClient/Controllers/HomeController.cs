using Microsoft.AspNetCore.Mvc;
using P11_HttpClient.Services;

namespace P11_HttpClient.Controllers;

public class HomeController : Controller
{
    private readonly FinnService _finnhubService;

    public HomeController(FinnService finnhubService)
    {
        _finnhubService = finnhubService;
    }

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        Dictionary<string,object>? dictionary = await _finnhubService.GetStockPriceQuote("MSFT");
        return View();
    }
}