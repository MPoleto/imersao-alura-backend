namespace stickers;

public interface IContentExtractor
{
  List<Content> ExtractContent(string json);
}
