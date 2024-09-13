using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiHexagonalNet.Domain.Models
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // ID normal generado por MongoDB

        public string Wid { get; set; } = string.Empty; // Worker ID único

        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty; // Relación con el usuario

        public Store()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Wid = Guid.NewGuid().ToString(); // Generar un Wid único por defecto
        }
    }
}
