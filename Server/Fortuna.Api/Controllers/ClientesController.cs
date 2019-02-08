using Fortuna.Domain.Entities;
using Fortuna.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        readonly IClienteService service;

        public ClientesController(IClienteService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Cliente>))]
        public async Task<IActionResult> GetAll()
        {
            var contactList = await service.GetAll();
            return Ok(contactList);
        }

        [HttpGet("{id}", Name = "GetClientes")]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await service.Find(id);
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
            await service.Add(item);
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

            var contactObj = await service.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }

            await service.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Remove(id);
            return NoContent();
        }
    }
}
