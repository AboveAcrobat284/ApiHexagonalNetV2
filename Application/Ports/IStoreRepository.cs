using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IStoreRepository
    {
        Task<Store> GetByIdAsync(string id);
        Task<IEnumerable<Store>> GetAllAsync();
        Task CreateAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(string id);
        Task<bool> WidExistsAsync(string wid); // Verificar existencia de Wid
        Task<IEnumerable<Store>> GetByUserIdAsync(string userId); // Obtener tiendas por ID de usuario
    }
}
