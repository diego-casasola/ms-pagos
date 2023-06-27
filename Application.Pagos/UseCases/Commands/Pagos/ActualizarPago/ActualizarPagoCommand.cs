using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagos.UseCases.Commands.Pagos.ActualizarPago
{
    public class ActualizarPagoCommand : IRequest<Guid>
    {
        public Guid IdPago { get; set; }
    }
}
