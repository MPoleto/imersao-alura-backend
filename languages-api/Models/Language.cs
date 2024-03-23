using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace languages_api;

public class Language
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string LanguageName { get; set; }

    [BsonElement("image")]
    [JsonPropertyName("image")]
    public string UrlImage { get; set; }
   
    [BsonElement("languageUsedCount")]
    [JsonPropertyName("languageUsedCount")]
    public int LanguageUsedCount { get; set; }
    
    [BsonElement("rank")]
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    
    [BsonConstructor]
    public Language(string languageName, string urlImage)
    {
        LanguageName = languageName;
        UrlImage = urlImage;
    }
}
