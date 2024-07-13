using Microsoft.Extensions.Configuration;

namespace stickers;

public class AccessData
{
    private readonly HttpClient _client;
    private IConfiguration _configuration;

    public AccessData(IConfiguration configuration)
    {
        _client = new();
        _configuration = configuration;
    }
    
    public async Task<string> GetData(string url, bool hasKey = false, string key = null!)
    {
        try
        {
          
            if (hasKey)
            {
                _client.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue(_configuration.GetSection(key).Value);
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = await _client.SendAsync(request, new CancellationToken());

            if(!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Status Code da resposta: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            
            throw new ClienteHttpException(ex.Message);
        }
    }
}
