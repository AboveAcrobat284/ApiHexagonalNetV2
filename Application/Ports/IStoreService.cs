using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllStores();
        Task<Store> GetStoreById(string id);
        Task CreateStore(Store store);
        Task UpdateStore(string id, Store store);
        Task DeleteStore(string id);
    }
}
