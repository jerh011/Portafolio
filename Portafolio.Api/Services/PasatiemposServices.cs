using MongoDB.Driver;


using PORTAFOLIO.API.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using PORTAFOLIO.API.Models;

namespace PORTAFOLIO.API.Services;

  
        
public class PasatiemposServices    
{
    private readonly IMongoCollection<Pasatiempos> _pasatiemposCollection;
    public PasatiemposServices( IOptions<DatabaseSettings> databaseSettings)
    {
        //Inicializar mi cliente de MongoDB 
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        //Conectar a la base de datos MongoDB
        var mongoDB =
        mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _pasatiemposCollection =
         mongoDB.GetCollection<Pasatiempos>
            (databaseSettings.Value.Collections["pasatiempos"]);
    }
   
    public async Task<List<Pasatiempos>> GetAsync() =>
    await _pasatiemposCollection.Find(_ => true).ToListAsync();
   
    public async Task<Pasatiempos> GetpasatiemposById(string id)
    {
        return await _pasatiemposCollection.FindAsync(new BsonDocument
    {{"_id",new ObjectId(id)}}).Result.FirstAsync();
    }

    public async Task Insertpasatiempos(Pasatiempos pasatiempos)
    {
        await _pasatiemposCollection.InsertOneAsync(pasatiempos);
    }
    public async Task Updatepasatiempos(Pasatiempos pasatiempos)
    {
        var filter = Builders<Pasatiempos>.Filter.Eq(S => S.Id, pasatiempos.Id);
        await _pasatiemposCollection.ReplaceOneAsync(filter, pasatiempos);
    }

    public async Task Delatepasatiempos(string id)
    {
        var filter = Builders<Pasatiempos>.Filter.Eq(S => S.Id, id);
        await _pasatiemposCollection.DeleteManyAsync(filter);
    }

}