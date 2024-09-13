using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiHexagonalNet.Domain.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // ID normal generado por MongoDB

        public string Wid { get; set; } = string.Empty; // Worker ID único

        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string StoreId { get; set; } = string.Empty; // Relación con la tienda

        // Constructor sin parámetros
        public Employee()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Wid = Guid.NewGuid().ToString(); // Generar un Wid único por defecto
        }
    }
}
