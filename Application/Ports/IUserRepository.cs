using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(string id);
        Task<IEnumerable<User>> GetAllAsync();
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
        Task<User> GetByWidAsync(string wid); // Obtener usuario por Wid
        Task<bool> WidExistsAsync(string wid); // Verificar existencia de Wid
    }
}
