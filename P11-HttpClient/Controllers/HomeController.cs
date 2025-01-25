using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using P11_HttpClient.Models;
using P11_HttpClient.Services;

namespace P11_HttpClient.Controllers;

public class HomeController : Controller
{
    private readonly FinnService _finnhubService;
    private readonly IOptions<TradingOptions> _tradingOptions;

    public HomeController(FinnService finnhubService, IOptions<TradingOptions> tradingOptions)
    {
        _finnhubService = finnhubService;
        _tradingOptions = tradingOptions;
    }

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        if (_tradingOptions.Value.DefaultStockSymbol == null)
        {
            _tradingOptions.Value.DefaultStockSymbol = "MSFT";
        }

        Dictionary<string, object> quoteDict =
            await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

        Stock stock = new Stock()
        {
            StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
            CurrentPrice = Convert.ToDouble(quoteDict["c"].ToString()),
            HighestPrice = Convert.ToDouble(quoteDict["h"].ToString()),
            LowestPrice = Convert.ToDouble(quoteDict["l"].ToString()),
            OpenPrice = Convert.ToDouble(quoteDict["o"].ToString())
        };

        return View(stock);
    }
}