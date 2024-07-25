namespace Ziplink.UserInterface.Services;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ziplink.UserInterface.Models;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> RedirectUrlAsync(string url)
    {
        var data = new { url = url };
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://localhost:7263/api/Url/RedirectUrl", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    public async Task<URLClient> AddURLAsync(URLClient urlClient)
    {
        var data = new URLClient();
        var url = "https://localhost:7263/api/Url/AddUrl"; // Replace with your actual URL

        try
        {
            // Example of sending a POST request with HttpClient
            var response = await _httpClient.PostAsJsonAsync(url, urlClient);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize response content if needed
                var responseData = await response.Content.ReadAsAsync<URLClient>();
                return responseData;
            }
            else
            {
                // Handle unsuccessful response
                return new URLClient();
            }
        }
        catch
        {
            // Handle exceptions
            return new URLClient();
        }
    }
}
