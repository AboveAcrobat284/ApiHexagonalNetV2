using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(string id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(string id, Employee employee);
        Task DeleteEmployee(string id);
        Task<List<Employee>> GetEmployeesByStoreId(string storeId); // Asegúrate de que esta línea esté aquí
    }
}
