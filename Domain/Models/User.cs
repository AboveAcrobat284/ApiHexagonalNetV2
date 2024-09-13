using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ApiHexagonalNet.Domain.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // ID normal generado por MongoDB

        public string Wid { get; set; } = string.Empty; // Worker ID único

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> StoreIds { get; set; } = new List<string>(); // Relación con las tiendas

        public User()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Wid = Guid.NewGuid().ToString(); // Generar un Wid único por defecto
        }
    }
}
