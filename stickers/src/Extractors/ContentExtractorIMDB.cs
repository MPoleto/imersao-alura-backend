using System.Text.Json;

namespace stickers;

public class ContentExtractorIMDB : IContentExtractor
{
  public List<Content> ExtractContent(string json)
  {
    List<Content> contents = new();

    using (JsonDocument document = JsonDocument.Parse(json))
    {
      JsonElement root = document.RootElement;
      JsonElement itemsElement = root.GetProperty("items");

      contents = itemsElement.EnumerateArray()
          .Select(p => new Content(
              Title: p.GetProperty("title").ToString()
                  .Replace(": ", "-")
                  .Replace(",", "")
                  .Trim(), 
              UrlImage: RemoveLimitationOfImageSize(p.GetProperty("image").ToString()))
              {
                Ranking = Convert.ToDouble(p.GetProperty("imDbRating").ToString().Replace('.', ','))
              })
          .ToList();
    }

    return contents;
  }

  private static string RemoveLimitationOfImageSize(string url)
  {
    string arroba = "@";
    string extensionPoint = ".";

    int start = url.IndexOf(arroba + 1);
    int end = url.LastIndexOf(extensionPoint);

    if (start == -1)
    {
      start = url.LastIndexOf("._");
    }
    int diference = end - start;

    return url.Remove(start, diference);
  }

}
