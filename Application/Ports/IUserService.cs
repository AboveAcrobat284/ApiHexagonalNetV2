using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByWid(string wid); 
        Task CreateUser(User user);
        Task UpdateUser(string id, User user);
        Task DeleteUser(string id);
        Task<List<Store>> GetStoresByUserId(string userId); 
        Task<List<User>> GetUsersByStoreId(string storeId); // Agregar esta línea
    }
}
