using Fortuna.Domain.Entities;
using Fortuna.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Api.Controllers
{
    [Route("api/clientes/{idCliente}/[controller]")]
    public class AlertasController : ControllerBase
    {
        readonly IAlertaService service;

        public AlertasController(IAlertaService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Alerta>))]
        public async Task<IActionResult> GetAll(int idCliente)
        {
            var contactList = await service.GetAll(idCliente);
            return Ok(contactList);
        }

        [HttpGet("{id}", Name = "GetAlertas")]
        [ProducesResponseType(200, Type = typeof(Alerta))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] int idCliente, int id)
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
        public async Task<IActionResult> Create([FromRoute] int idCliente, [FromBody] Alerta item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await service.Add(idCliente, item);
            return CreatedAtRoute("GetAlertas", new { id = item.IdAlerta }, item);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromRoute] int idCliente, int id, [FromBody] Alerta item)
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
        public async Task<IActionResult> Delete([FromRoute] int idCliente, int id)
        {
            await service.Remove(id);
            return NoContent();
        }
    }
}
