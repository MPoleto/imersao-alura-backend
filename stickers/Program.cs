using stickers;
using stickers.DesafioAula1;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Conexão HTTP

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

  for (int i = 11; i < 14; i++)
  {
    string nameImage = movies[i].GetValueOrDefault("title").Replace(": ", "-").Replace(",", "");
    string urlImage = movies[i].GetValueOrDefault("image");
    double rating = double.Parse(movies[i].GetValueOrDefault("imDbRating")!.Replace('.', ','));

    Console.WriteLine($"\u001b[42m\u001b[1m{nameImage,67} \u001b[m");
    Console.Write($"Rating: {rating}");

    int count = 1;
    while (rating >= count)
    {
      Console.Write("⭐ ");

      count++;
    }

    string newUrlImage = RemoveLimitationOfImageSize(urlImage);

    string text = AddTextByRating(i, rating);

    nameImage = $"{i + 1}-{nameImage}";

    geradora.CreateSticker(newUrlImage, text, nameImage);

    Console.WriteLine();
    Console.WriteLine("\r\n");
  }

}

// Desafios - Aula 2
static string RemoveLimitationOfImageSize(string url)
{
  // Tratar imagem para pegá-las em tamanho maior
  string arroba = "@";
  string pontoDaExtensao = ".";

  int start = url.IndexOf(arroba+1);
  int end = url.LastIndexOf(pontoDaExtensao);

  if(start == -1)
  {
    start = url.LastIndexOf("._");
  }
  int diference = end - start;

  return url.Remove(start, diference);
}

static string AddTextByRating(int index, double rating)
{
  string text = "";

  if(index < 10 && rating >= 9) text = "TOPZERA";
  else if(index < 10 && rating < 9 && rating >= 8.8) text = "TOP";
  else if(index >= 10 && index < 100 && rating >= 8.5) text = "COOL";
  else text = "OK";

  return text;
}

// Desafios - Aula 1
/*
DataAPI getMovies = new();
var moviesList = await getMovies.GetDataAPI(url);
getMovies.PersonalRating(moviesList);
getMovies.ViewData(moviesList);
*/



