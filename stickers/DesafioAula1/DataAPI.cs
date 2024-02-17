using System.Text.Json;

namespace stickers.DesafioAula1;

public class DataAPI
{
  private readonly HttpClient _client;

  public DataAPI()
  {
    _client = new HttpClient();
  }

  public async Task<MoviesList> GetDataAPI(string url)
  {
    using var request = new HttpRequestMessage(HttpMethod.Get, url);
    using var response = await _client.SendAsync(request, new CancellationToken());
    response.EnsureSuccessStatusCode();

    var content = await response.Content.ReadAsStringAsync();
    var movies = JsonSerializer.Deserialize<MoviesList>(content);

    return movies;
  }

  public void ViewData(MoviesList movies)
  {
    foreach (var movie in movies.Movie)
    {
      Console.WriteLine($"\u001b[42m\u001b[1m {movie.Title,67} \u001b[m");
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

      if (movie.PersonalRating != 0)
      {
        Console.Write($" Sua nota: ");
        count = 1;
        while (movie.PersonalRating >= count)
        {
          Console.Write("💚 ");

          count++;
        }
      }

      Console.WriteLine("\r\n");
      Console.WriteLine("\r\n");
    }
  }

  public void PersonalRating(MoviesList movies)
  {
    Console.WriteLine($"Qual a sua nota para os seguintes filmes:");

    for (var i = 0; i < movies.Movie.Count; i++)
    {
      Console.Write($"{movies.Movie[i].Title}: ");

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
      movies.Movie[i].PersonalRating = notaPessoal;
    }
    Console.WriteLine("\r\n");
    Console.WriteLine("\r\n");
  }
}
