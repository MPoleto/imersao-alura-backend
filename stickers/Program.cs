using stickers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Conexão HTTP

string url = "https://raw.githubusercontent.com/alexfelipe/imersao-java/json/top250.json";


using (HttpClient client = new())
using (var request = new HttpRequestMessage(HttpMethod.Get, url))
using (var response = await client.SendAsync(request, new CancellationToken()))
{
  response.EnsureSuccessStatusCode();
  var content = await response.Content.ReadAsStringAsync();
  

  // Extrair dados de interesse: titulo, poster, classificação
  JsonParser parser = new();
  List<Dictionary<string, string>> ListMovies = parser.ParseJson(content);
  
  // Exibir e manipular os dados

  foreach (var movie in ListMovies)
  {
    Console.WriteLine($"Título: {movie.GetValueOrDefault("title")}");
    Console.WriteLine($"Imagem: {movie.GetValueOrDefault("image")}");
    Console.Write($"Rating: {movie.GetValueOrDefault("imDbRating")}");

    Console.WriteLine("\r\n");
  }
}



