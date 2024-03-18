using MongoDB.Driver;


using PORTAFOLIO.API.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using PORTAFOLIO.API.Models;

namespace PORTAFOLIO.API.Services;

  
        
public class TecnologiaServices    
{
    private readonly IMongoCollection<Tecnologias> _driverCollection;
    public TecnologiaServices( IOptions<DatabaseSettings> databaseSettings)
    {
        //Inicializar mi cliente de MongoDB 
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        //Conectar a la base de datos MongoDB
        var mongoDB =
        mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _driverCollection =
         mongoDB.GetCollection<Tecnologias>
            (databaseSettings.Value.Collections["tecnologias"]);
    }
   
    public async Task<List<Tecnologias>> GetAsync() =>
    await _driverCollection.Find(_ => true).ToListAsync();
   
    public async Task<Tecnologias> GetTecnologiasById(string id)
    {
        return await _driverCollection.FindAsync(new BsonDocument
    {{"_id",new ObjectId(id)}}).Result.FirstAsync();
    }

    public async Task InsertTecnologias(Tecnologias tecnologias)
    {
        await _driverCollection.InsertOneAsync(tecnologias);
    }
    public async Task UpdateTecnologias(Tecnologias tecnologias)
    {
        var filter = Builders<Tecnologias>.Filter.Eq(S => S.Id, tecnologias.Id);
        await _driverCollection.ReplaceOneAsync(filter, tecnologias);
    }

    public async Task DelateTecnologias(string id)
    {
        var filter = Builders<Tecnologias>.Filter.Eq(S => S.Id, id);
        await _driverCollection.DeleteManyAsync(filter);
    }

}