using System.Text.Json;

namespace stickers;

public class ContentExtractorNasa : IContentExtractor
{
  public List<Content> ExtractContent(string json)
  {
    List<Content> contents = new();

    using (JsonDocument document = JsonDocument.Parse(json))
    {
      JsonElement root = document.RootElement;

      contents = root.EnumerateArray()
          .Select(p => new Content(
              Title: p.GetProperty("title").ToString()
                  .Replace(": ", "-")
                  .Replace(",", "")
                  .Trim(), 
              UrlImage: p.GetProperty("url").ToString()))
          .ToList();
    }

    return contents;
  }
}
