﻿using Application.Pagos.UseCases.Commands.Pagos.RegistrarPagos;
using Application.Pagos.UseCases.Queries.Pago;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace WebApp.Pagos.Controllers
{
    [Route("api/pago")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetPagoByIdQuery()
            {
                IdPago = id
            };
            var result = await _mediator.Send(query);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [Route("qr/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetQR([FromRoute] Guid id)
        {
            var query = new GetPagoByIdQuery()
            {
                IdPago = id
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }

            string jsonResult = JsonSerializer.Serialize(result);
            string base64Result = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonResult));

            return Ok(base64Result);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePago([FromBody] RegistrarPagoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //update pago solo el estado
        //[Route("{id}")]
        //[HttpPut]
    }
}
