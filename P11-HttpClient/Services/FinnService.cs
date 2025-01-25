using System.Text.Json;
using P11_HttpClient.ServiceContracts;

namespace P11_HttpClient.Services;

public class FinnService : IFinnhubService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public FinnService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<Dictionary<string, object>> GetStockPriceQuote(string stockSymbol)
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri =
                    new Uri(
                        $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}"),
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