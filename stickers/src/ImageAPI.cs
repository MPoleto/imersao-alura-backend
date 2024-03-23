using System.Reflection;

namespace stickers;

public class ImageAPI
{
    private readonly string _url;
    private readonly IContentExtractor _extractor;
    private readonly bool _hasKey;
    private readonly string _key;

    public ImageAPI(string url, IContentExtractor extractor, bool hasKey = false, string key = null!)
    {
        _url = url;
        _extractor = extractor;
        _hasKey = hasKey;
        _key = key;
    }

    public static List<ImageAPI> Values 
    {
        get
        {
            return new List<FieldInfo> (IMDB.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static))
                .Where(f => f.FieldType == typeof(ImageAPI))
                .Select(f => (ImageAPI) f.GetValue(null)!)
                .ToList();
        }
    }

    public string URL()
    {
        return _url;
    }

    public IContentExtractor Extractor()
    {
        return _extractor;
    }

    public bool HasKey()
    {
        return _hasKey;
    }

    public string Key()
    {
        return _key;
    }
    
    public static readonly ImageAPI IMDB = new(@"https://mocki.io/v1/9a7c1ca9-29b4-4eb3-8306-1adb9d159060", new ContentExtractorIMDB());
    public static readonly ImageAPI NASA = new(@"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&start_date=2024-01-01&end_date=2024-01-05", new ContentExtractorNasa());
    public static readonly ImageAPI PEXELS = new(@"https://api.pexels.com/v1/curated?per_page=5", new ContentExtractorPexels(), true, "PexelsKey");
    public static readonly ImageAPI LANGUAGES = new(@"https://localhost:7258/language", new ContentExtractorLanguage());

}
