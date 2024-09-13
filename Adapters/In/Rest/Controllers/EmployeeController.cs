using Microsoft.AspNetCore.Mvc;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Adapters.In.Rest.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("store/{storeId}/employees")]
        public async Task<IActionResult> GetEmployeesByStoreId(string storeId)
        {
            var employees = await _employeeService.GetEmployeesByStoreId(storeId);
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            await _employeeService.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del objeto.");
            }

            await _employeeService.UpdateEmployee(id, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            await _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }
}
