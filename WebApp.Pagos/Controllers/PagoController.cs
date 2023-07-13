using Application.Pagos.UseCases.Commands.Pagos.RegistrarPagos;
using Application.Pagos.UseCases.Queries.Pago;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Application.Pagos.UseCases.Commands.Pagos.ActualizarPago;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

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

        [Route("image/qr/{id}")]
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

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string json = JsonSerializer.Serialize(result);
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(json, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, ImageFormat.Png);
                byte[] imageBytes = stream.ToArray();

                return Ok(imageBytes);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreatePago([FromBody] RegistrarPagoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //update pago solo el estado
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePago([FromRoute] Guid id, [FromBody] ActualizarPagoCommand command)
        {
            command.IdPago = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
