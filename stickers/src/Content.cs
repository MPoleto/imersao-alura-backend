namespace stickers;

public record Content (string Title, string UrlImage)
{
    public double Ranking { get; init; }
}
