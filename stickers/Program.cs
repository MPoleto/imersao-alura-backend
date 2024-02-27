using Microsoft.Extensions.Configuration;
using stickers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var http = new AccessData(configuration);

// IMDB
// string json = await http.GetData(ImageAPI.IMDB.URL());
// List<Content> contents = ImageAPI.IMDB.Extractor().ExtractContent(json);

// NASA
// string json = await http.GetData(ImageAPI.NASA.URL());
// List<Content> contents = ImageAPI.NASA.Extractor().ExtractContent(json);

// Pexels
string json = await http.GetData(ImageAPI.PEXELS.URL(), ImageAPI.PEXELS.HasKey(), ImageAPI.PEXELS.Key());
List<Content> contents = ImageAPI.PEXELS.Extractor().ExtractContent(json);

var stickers = new StickersGenerator();

for (var i = 0; i < 5; i++)
{
  Content content = contents[i];

  string text;

  if (content.Ranking != 0)
  {
    text = ModifyText.AddTextByRating(i, content.Ranking);
  }
  else text = "SHOW";

  stickers.CreateSticker(content.UrlImage, text, $"{content.Title}");
}

