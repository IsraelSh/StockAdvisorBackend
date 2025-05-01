using System.Text.Json;

public class PolygonService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "B3oUsO0EkvpF9xzR8vq2ob4XDP4zcx80\r\n";

    public PolygonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<double?> GetLatestPrice(string symbol)
    {
        try
        {
            var url = $"https://api.polygon.io/v2/aggs/ticker/{symbol}/prev?adjusted=true&apiKey={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);

            return doc.RootElement.GetProperty("results")[0].GetProperty("c").GetDouble();
        }
        catch
        {
            return null;
        }
    }



}
