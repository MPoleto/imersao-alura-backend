using stickers;
using stickers.DesafioAula1;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Conexão HTTP

// IMDB
string url = "https://mocki.io/v1/9a7c1ca9-29b4-4eb3-8306-1adb9d159060";
IExtratorDeConteudo extrator = new ExtratorDeConteudoDoIMDB();

// NASA
//string url = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&start_date=2024-01-01&end_date=2024-01-05";
//IExtratorDeConteudo extrator = new ExtratorDeConteudoDaNasa();

var http = new ClienteHttp();
string json = await http.BuscaDados(url);

// Extrair dados de interesse: titulo, poster, classificação
List<Conteudo> conteudos = extrator.ExtraiConteudos(json);

  
// Exibir e manipular os dados
var geradora = new GeradoraDeFigurinhas();

for (var i = 0; i < 3; i++)
{
  Conteudo conteudo = conteudos[i];

  geradora.CreateSticker(conteudo.UrlImagem, "TOPZERA", conteudo.Titulo);
}

// Desafios - Aula 1
/*
DataAPI getMovies = new();
var moviesList = await getMovies.GetDataAPI(url);
getMovies.PersonalRating(moviesList);
getMovies.ViewData(moviesList);
*/



