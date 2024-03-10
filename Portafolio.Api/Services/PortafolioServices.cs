using MongoDB.Driver;


using PORTAFOLIO.API.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using PORTAFOLIO.API.Models;

namespace PORTAFOLIO.API.Services;

  
        
public class PortafolioServices    
{
    private readonly IMongoCollection<Perfil> _driverCollection;
    public PortafolioServices( IOptions<DatabaseSettings> databaseSettings)
    {
        //Inicializar mi cliente de MongoDB 
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
       //Conectar a la base de datos MongoDB
        var mongoDB =
        mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _driverCollection =
         mongoDB.GetCollection<Perfil>
            (databaseSettings.Value.CollectionName);
    }
   
    public async Task<List<Perfil>> GetAsync() =>
    await _driverCollection.Find(_ => true).ToListAsync();
   
    public async Task<Perfil> GetPerfilById(string id)
    {
        return await _driverCollection.FindAsync(new BsonDocument
    {{"_id",new ObjectId(id)}}).Result.FirstAsync();
    }

    public async Task InsertPerfil(Perfil drivers)
    {
        await _driverCollection.InsertOneAsync(drivers);
    }
    public async Task UpdatePerfil(Perfil drivers)
    {
        var filter = Builders<Perfil>.Filter.Eq(S => S.Id, drivers.Id);
        await _driverCollection.ReplaceOneAsync(filter, drivers);
    }

    public async Task DelatePerfil(string id)
    {
        var filter = Builders<Perfil>.Filter.Eq(S => S.Id, id);
        await _driverCollection.DeleteManyAsync(filter);
    }

}