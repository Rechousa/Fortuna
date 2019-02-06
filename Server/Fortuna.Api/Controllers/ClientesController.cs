using Fortuna.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Cliente>))]
        public async Task<IActionResult> GetAll()
        {
            var contactList = await DummyClientesRepository.GetAll();
            return Ok(contactList);
        }

        [HttpGet("{id}", Name = "GetClientes")]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await DummyClientesRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Cliente item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await DummyClientesRepository.Add(item);
            return CreatedAtRoute("GetClientes", new { id = item.IdCliente }, item);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var contactObj = await DummyClientesRepository.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }

            await DummyClientesRepository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            await DummyClientesRepository.Remove(id);
            return NoContent();
        }
    }
}
