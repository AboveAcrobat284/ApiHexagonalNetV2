using Microsoft.AspNetCore.Mvc;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Adapters.In.Rest.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}/stores")]
        public async Task<IActionResult> GetStoresByUserId(string id)
        {
            var stores = await _userService.GetStoresByUserId(id);
            return Ok(stores);
        }

        [HttpGet("store/{storeId}/users")]
        public async Task<IActionResult> GetUsersByStoreId(string storeId)
        {
            var users = await _userService.GetUsersByStoreId(storeId);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del objeto.");
            }

            await _userService.UpdateUser(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
