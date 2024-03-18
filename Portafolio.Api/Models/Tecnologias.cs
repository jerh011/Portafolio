using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PORTAFOLIO.API.Models;

public class Tecnologias{
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
public string Id{get;set;}

[BsonElement("tecnologia")]
public string tecnologia{get;set;}

[BsonElement("UrlImg")]
public string UrlImg{get;set;}
}