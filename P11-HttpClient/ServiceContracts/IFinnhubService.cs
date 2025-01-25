namespace P11_HttpClient.ServiceContracts;

public interface IFinnhubService
{
    Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
}