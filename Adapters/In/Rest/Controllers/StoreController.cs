using Microsoft.AspNetCore.Mvc;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Adapters.In.Rest.Controllers
{
    [ApiController]
    [Route("api/store")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var stores = await _storeService.GetAllStores();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(string id)
        {
            var store = await _storeService.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] Store store)
        {
            await _storeService.CreateStore(store);
            return CreatedAtAction(nameof(GetStoreById), new { id = store.Id }, store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(string id, [FromBody] Store store)
        {
            if (id != store.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del objeto.");
            }

            await _storeService.UpdateStore(id, store);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(string id)
        {
            await _storeService.DeleteStore(id);
            return NoContent();
        }
    }
}
