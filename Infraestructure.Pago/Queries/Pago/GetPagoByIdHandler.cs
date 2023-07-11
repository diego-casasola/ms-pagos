using Application.Pagos.Dto;
using Application.Pagos.UseCases.Queries.Pago;
using Domain.Pagos.Model.Pago;
using Infraestructure.Pagos.EF.Context;
using Infraestructure.Pagos.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Pagos.Queries.Pago
{
    internal class GetPagoByIdHandler : IRequestHandler<GetPagoByIdQuery, PagoDto>
    {
        private readonly DbSet<PagoReadModel> pagos;

        public GetPagoByIdHandler(ReadDbContext dbContext)
        {
            pagos = dbContext.Pagos;
        }

        public async Task<PagoDto> Handle(GetPagoByIdQuery request, CancellationToken cancellationToken)
        {
            var pago = await pagos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdPago == request.IdPago);

            if(pago == null)
            {
                return null;
            }
            return new PagoDto()
            {
                IdPago = pago.IdPago,
                ProyectoId = pago.ProyectoId,
                Monto = pago.Monto,
                Estado = pago.Estado
            };
        }
    }
}
