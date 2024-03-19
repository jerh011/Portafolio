using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PORTAFOLIO.API.Models;

public class Pasatiempos{
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
public string Id{get;set;}

[BsonElement("nombre")]
public string nombre{get;set;}

[BsonElement("urlIMG")]
public string urlIMG{get;set;}


[BsonElement("horas")]
public string horas{get;set;}

[BsonElement("detalle")]
public string detalle{get;set;}



}