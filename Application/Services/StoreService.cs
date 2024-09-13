using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiHexagonalNet.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<List<Store>> GetAllStores()
        {
            var stores = await _storeRepository.GetAllAsync();
            return stores.ToList();
        }

        public async Task<Store> GetStoreById(string id)
        {
            return await _storeRepository.GetByIdAsync(id);
        }

        public async Task CreateStore(Store store)
        {
            while (await _storeRepository.WidExistsAsync(store.Wid))
            {
                store.Wid = Guid.NewGuid().ToString(); // Generar un nuevo Wid hasta que sea único
            }

            await _storeRepository.CreateAsync(store);
        }

        public async Task UpdateStore(string id, Store store)
        {
            if (id != store.Id)
            {
                throw new ArgumentException("El ID proporcionado no coincide con el ID del objeto.");
            }
            await _storeRepository.UpdateAsync(store);
        }

        public async Task DeleteStore(string id)
        {
            await _storeRepository.DeleteAsync(id);
        }
    }
}
