using System.Text.Json;
using P11_HttpClient.ServiceContracts;

namespace P11_HttpClient.Services;

public class FinnService : IFinnhubService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FinnService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Dictionary<string, object>> GetStockPriceQuote(string stockSymbol)
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri =
                    new Uri(
                        $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token=cu6q63hr01qh2ki6a4agcu6q63hr01qh2ki6a4b0"),
                Method = HttpMethod.Get
            };
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            Stream stream = httpResponseMessage.Content.ReadAsStream();

            string response = new StreamReader(stream).ReadToEnd();
            Dictionary<string, object>? responseDict = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            if (responseDict == null)
                throw new InvalidOperationException("No response from Finnhub Server");

            if (responseDict.ContainsKey("error"))
                throw new InvalidCastException(Convert.ToString(responseDict["error"]));

            return responseDict;
        }
    }
}