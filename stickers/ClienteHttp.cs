namespace stickers;

public class ClienteHttp
{
    public async Task<string> BuscaDados(string url)
    {
      try
      {
        HttpClient client = new();
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response = await client.SendAsync(request, new CancellationToken());

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        return content;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message, ex.InnerException);
      }
    }
}
