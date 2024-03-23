using MongoDB.Driver;
using MongoDB.Bson;

namespace languages_api;

public class LanguageDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollectionName { get; set; } = null!;
}
