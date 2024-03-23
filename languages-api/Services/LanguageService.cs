using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace languages_api;

public class LanguageService
{
    private IMongoCollection<Language> _collection;

    public LanguageService(IOptions<LanguageDatabaseSettings> languageDbSettings)
    {
      var client = new MongoClient(languageDbSettings.Value.ConnectionString);

      var mongoDatabase = client.GetDatabase(languageDbSettings.Value.DatabaseName);

      _collection = mongoDatabase.GetCollection<Language>(languageDbSettings.Value.CollectionName);
    }

    public List<Language> FindAll()
    {
      return _collection.Find(l => true).ToList();
    }

    public List<Language> SortByRank()
    {
      var sort = Builders<Language>.Sort.Ascending(l => l.Rank);

      return _collection.Find(l => true).Sort(sort).ToList();
    }

    public Language FindById(string id)
    {
      return _collection.Find(l => l.Id == id).FirstOrDefault();
    }

    public Language FindByName(string languageName)
    {
      var filter = Builders<Language>.Filter.Where(l => l.LanguageName.ToLower().Contains(languageName.ToLower()));

      return _collection.Find(filter).FirstOrDefault();
      // return _collection.AsQueryable()
      //         .Where(l => l.LanguageName.ToLower() == languageName.ToLower())
      //         .FirstOrDefault();
    }

    public void Create(Language newLanguage)
    {
      _collection.InsertOne(newLanguage);
    }

    public void Update(string id, Language updatedLanguage)
    {
      _collection.ReplaceOne(l => l.Id == id, updatedLanguage);
    }

    public void UpdateAccessCount(string languageName)
    {
      var filter = Builders<Language>.Filter.Where(l => l.LanguageName.ToLower().Contains(languageName.ToLower()));

      var value = _collection.Find(filter).FirstOrDefault().LanguageUsedCount;
      var update = Builders<Language>.Update.Set(l => l.LanguageUsedCount, value+1);
      
      _collection.UpdateOne(filter, update);

      UpdateRanking();
    }

    public void Remove(string id)
    {
      _collection.DeleteOne(l => l.Id == id);
    }

    private void UpdateRanking()
    {
      var pipeline = new BsonDocument[]
      {
          new("$setWindowFields", 
          new BsonDocument
          {
            { "sortBy", 
              new BsonDocument("languageUsedCount", -1) 
            }, 
            { "output", 
              new BsonDocument("rank", 
              new BsonDocument("$documentNumber", 
              new BsonDocument())) 
            }
          })
      };

      PipelineDefinition<Language, Language> pipelineQueryable = pipeline;
      var merge = PipelineStageDefinitionBuilder.Merge<Language, Language>(_collection, new MergeStageOptions<Language>());
      var mergePipeline = pipelineQueryable.AppendStage(merge);
      _collection.AggregateToCollection(mergePipeline);
      
    }
}
