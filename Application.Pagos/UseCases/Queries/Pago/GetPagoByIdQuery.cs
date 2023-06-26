using Application.Pagos.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagos.UseCases.Queries.Pago
{
    public class GetPagoByIdQuery : IRequest<PagoDto>
    {
        public Guid IdPago { get; set; }
    }
}
