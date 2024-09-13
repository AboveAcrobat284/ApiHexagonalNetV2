using MongoDB.Driver;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiHexagonalNet.Domain.Settings;
using Microsoft.Extensions.Options;

namespace ApiHexagonalNet.Adapters.Out.Persistence.MongoDB
{
    public class MongoDBEmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public MongoDBEmployeeRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Employee>("Employees");
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Employee employee)
        {
            await _collection.InsertOneAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _collection.ReplaceOneAsync(e => e.Id == employee.Id, employee);
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
    }
}
