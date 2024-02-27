using System.Text.Json;
namespace stickers;

public class ContentExtractorPexels : IContentExtractor
{
  public List<Content> ExtractContent(string json)
  {
    List<Content> contents = new();

    using (JsonDocument document = JsonDocument.Parse(json))
    {
      JsonElement root = document.RootElement;
      JsonElement photosElement = root.GetProperty("photos");

      contents = photosElement.EnumerateArray()
          .Select(p => new Content(
              Title: p.GetProperty("alt").ToString().Replace(": ", "-").Replace(",", "").Trim(),
              UrlImage: p.GetProperty("src").GetProperty("original").ToString()))
          .ToList();
    }

    return contents;
  }
}
