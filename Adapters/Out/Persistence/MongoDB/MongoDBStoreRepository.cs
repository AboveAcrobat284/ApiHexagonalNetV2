using MongoDB.Driver;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiHexagonalNet.Domain.Settings;
using Microsoft.Extensions.Options;

namespace ApiHexagonalNet.Adapters.Out.Persistence.MongoDB
{
    public class MongoDBStoreRepository : IStoreRepository
    {
        private readonly IMongoCollection<Store> _collection;

        public MongoDBStoreRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Store>("Stores");
        }

        public async Task<Store> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Store store)
        {
            await _collection.InsertOneAsync(store);
        }

        public async Task UpdateAsync(Store store)
        {
            await _collection.ReplaceOneAsync(e => e.Id == store.Id, store);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }

        public async Task<bool> WidExistsAsync(string wid)
        {
            var count = await _collection.CountDocumentsAsync(e => e.Wid == wid);
            return count > 0;
        }

        public async Task<IEnumerable<Store>> GetByUserIdAsync(string userId)
        {
            return await _collection.Find(e => e.UserId == userId).ToListAsync();
        }
    }
}
