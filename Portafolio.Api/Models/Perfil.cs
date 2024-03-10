using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PORTAFOLIO.API.Models;

public class Perfil{
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
public string Id{get;set;}

[BsonElement("nombre")]
public string nombre{get;set;}

[BsonElement("segundoNombre")]
public string segundoNombre{get;set;}

[BsonElement("apellidoPaterno")]
public string apellidoPaterno{get;set;}

[BsonElement("apellidoMaterno")]
public string apellidoMaterno{get;set;}

[BsonElement("edad")]
public string edad{get;set;}

[BsonElement("numeroCelular")]
public string numeroCelular{get;set;}

[BsonElement("correo")]
public string correo{get;set;}

[BsonElement("correo1")]
public string correo1{get;set;}

[BsonElement("facebook")]
public string facebook{get;set;}

[BsonElement("github")]
public string github{get;set;}

}