using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiHexagonalNet.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.ToList();
        }

        public async Task<Employee> GetEmployeeById(string id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task CreateEmployee(Employee employee)
        {
            while (await _employeeRepository.WidExistsAsync(employee.Wid))
            {
                employee.Wid = Guid.NewGuid().ToString(); // Generar un nuevo Wid hasta que sea único
            }
            
            await _employeeRepository.CreateAsync(employee);
        }

        public async Task UpdateEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                throw new ArgumentException("El ID proporcionado no coincide con el ID del objeto.");
            }
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployee(string id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<List<Employee>> GetEmployeesByStoreId(string storeId)
        {
            var allEmployees = await _employeeRepository.GetAllAsync();
            var employeesWithStore = allEmployees.Where(employee => employee.StoreId == storeId).ToList();
            return employeesWithStore;
        }
    }
}
