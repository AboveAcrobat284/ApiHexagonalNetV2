using MongoDB.Driver;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiHexagonalNet.Domain.Settings;
using Microsoft.Extensions.Options;

namespace ApiHexagonalNet.Adapters.Out.Persistence.MongoDB
{
    public class MongoDBUserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public MongoDBUserRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<User>("Users");
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(User user)
        {
            await _collection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _collection.ReplaceOneAsync(e => e.Id == user.Id, user);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }

        public async Task<User> GetByWidAsync(string wid)
        {
            return await _collection.Find(e => e.Wid == wid).FirstOrDefaultAsync();
        }

        public async Task<bool> WidExistsAsync(string wid)
        {
            var count = await _collection.CountDocumentsAsync(e => e.Wid == wid);
            return count > 0;
        }
    }
}
