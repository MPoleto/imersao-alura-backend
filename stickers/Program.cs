using stickers;
using stickers.DesafioAula1;

Console.OutputEncoding = System.Text.Encoding.UTF8;


// var geradora = new GeradoraDeFigurinhas();
// geradora.Criar();

// Conexão HTTP

//string url = "https://raw.githubusercontent.com/alexfelipe/imersao-java/json/top250.json";
string url = "https://mocki.io/v1/9a7c1ca9-29b4-4eb3-8306-1adb9d159060";

HttpClient client = new();
using (var request = new HttpRequestMessage(HttpMethod.Get, url))
using (var response = await client.SendAsync(request, new CancellationToken()))
{
  response.EnsureSuccessStatusCode();
  var content = await response.Content.ReadAsStringAsync();

  // Extrair dados de interesse: titulo, poster, classificação
  JsonParser parser = new();
  List<Dictionary<string, string>> movies = parser.ParseJson(content);
  
  // Exibir e manipular os dados
  var geradora = new GeradoraDeFigurinhas();

  for(int i = 23; i < 28; i++)
  {
    Console.WriteLine($"\u001b[42m\u001b[1m{movies[i].GetValueOrDefault("title"),67} \u001b[m");
    double rating = double.Parse(movies[i].GetValueOrDefault("imDbRating")!.Replace('.', ','));
    int count = 1;
    Console.Write($"Rating: ");
    while (rating >= count)
    {
      Console.Write("💚 ");

      count++;
    }
    Console.WriteLine("\r\n");
    Console.WriteLine("\r\n");

    var urlImage = movies[i].GetValueOrDefault("image");
    var nomeImagem = "./saida/" + movies[i].GetValueOrDefault("title") + ".png";
    geradora.Criar(urlImage, nomeImagem);
  }

}

// Desafios - Aula 1
/*
DataAPI getMovies = new();
var moviesList = await getMovies.GetDataAPI(url);
getMovies.PersonalRating(moviesList);
getMovies.ViewData(moviesList);
*/



