using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(string id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(string id);
        Task<bool> WidExistsAsync(string wid); // Verificar existencia de Wid
    }
}
