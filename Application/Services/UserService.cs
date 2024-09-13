using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiHexagonalNet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStoreRepository _storeRepository;

        public UserService(IUserRepository userRepository, IStoreRepository storeRepository)
        {
            _userRepository = userRepository;
            _storeRepository = storeRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ToList();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByWid(string wid)
        {
            return await _userRepository.GetByWidAsync(wid);
        }

        public async Task CreateUser(User user)
        {
            while (await _userRepository.WidExistsAsync(user.Wid))
            {
                user.Wid = Guid.NewGuid().ToString(); // Generar un nuevo Wid hasta que sea único
            }
            
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUser(string id, User user)
        {
            if (id != user.Id)
            {
                throw new ArgumentException("El ID proporcionado no coincide con el ID del objeto.");
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUser(string id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<Store>> GetStoresByUserId(string userId)
        {
            var stores = await _storeRepository.GetByUserIdAsync(userId);
            return stores.ToList();
        }

        public async Task<List<User>> GetUsersByStoreId(string storeId) // Implementación del método
        {
            var allUsers = await _userRepository.GetAllAsync();
            var usersWithStore = allUsers.Where(user => user.StoreIds.Contains(storeId)).ToList();
            return usersWithStore;
        }
    }
}
