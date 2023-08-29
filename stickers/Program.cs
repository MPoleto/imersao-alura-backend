using System.Text.Json;
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
  List<Dictionary<string, string>> movies = parser.ParseJson(content);
  
  // Exibir e manipular os dados
  
  foreach (var movie in movies)
  {
    Console.WriteLine($"\u001b[42m\u001b[1m{movie.GetValueOrDefault("title"),67} \u001b[m");
    Console.WriteLine($"Imagem:\u001b[3m {movie.GetValueOrDefault("image")} \u001b[m");

    double rating = double.Parse(movie.GetValueOrDefault("imDbRating")!.Replace('.', ','));
    int count = 1;
    Console.Write($"Rating: ");
    while (rating >= count)
    {
      Console.Write("💚 ");

      count++;
    }
    Console.WriteLine("\r\n");
    Console.WriteLine("\r\n");
  }



  // Desafios:

  var moviesList = JsonSerializer.Deserialize<MoviesList>(content);

  RatingMovie(); 

  foreach (var movie in moviesList.Movie)
  {
    Console.WriteLine($"\u001b[42m\u001b[1m {movie.Title, 67} \u001b[m");
    Console.WriteLine($" Imagem: \u001b[3m {movie.Image} \u001b[m");
    
    double rating = double.Parse(movie.Rating!.Replace('.', ','));
    int count = 1;
    Console.Write($" Rating:  ");
    while (rating >= count)
    {
      Console.Write(" ⭐");

      count++;
    }

    Console.WriteLine();
    Console.Write($" Sua nota: ");
    count = 1;
    while (movie.PersonalRating >= count)
    {
      Console.Write("💚 ");

      count++;
    }
    
    Console.WriteLine("\r\n");
    Console.WriteLine("\r\n");
  }

  void RatingMovie() {
    Console.WriteLine("Qual sua nota para os filmes?");

    for (var i = 0; i < moviesList.Movie.Count; i++)
    {

      Console.Write($"{moviesList.Movie[i].Title}: ");
      int notaPessoal = 0;
      bool invalid = true;
      while (invalid)
      {
        bool nota = int.TryParse(Console.ReadLine(), out notaPessoal);
        if (notaPessoal > 0 && notaPessoal <= 10)
        {
          invalid = false;
        }
        else
        {
          Console.WriteLine("Nota inválida. Tente novamente.");
        }
      }
      moviesList.Movie[i].PersonalRating = notaPessoal;
    }
  }
}



