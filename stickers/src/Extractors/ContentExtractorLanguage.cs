using System.Text.Json;

namespace stickers;

public class ContentExtractorLanguage : IContentExtractor
{
    public List<Content> ExtractContent(string json)
    {
        List<Content> contents = new();

        using (JsonDocument document = JsonDocument.Parse(json))
        {
            JsonElement root = document.RootElement;

            contents = root.EnumerateArray()
                .Select(p => new Content(
                    Title: p.GetProperty("name").ToString()
                        .Replace(": ", "-")
                        .Replace("#", "sharp")
                        .Trim(), 
                    UrlImage: p.GetProperty("image").ToString()))
                .ToList();
        }

      return contents;
  }
}
