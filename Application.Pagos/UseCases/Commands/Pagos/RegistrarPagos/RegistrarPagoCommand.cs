using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagos.UseCases.Commands.Pagos.RegistrarPagos
{
    public class RegistrarPagoCommand : IRequest<Guid>
    {
        public Guid IdPago { get; set; }
        public Guid ProyectoId { get; set; }
        public decimal Monto { get; set;}
        public int Estado { get; set;}

        public RegistrarPagoCommand(Guid idPago, Guid proyectoId, decimal monto, int estado)
        {
            IdPago = idPago;
            ProyectoId = proyectoId;
            Monto = monto;
            Estado = estado;
        }

        public RegistrarPagoCommand(Guid idPago, Guid proyectoId, decimal monto)
        {
            IdPago = idPago;
            ProyectoId = proyectoId;
            Monto = monto;
        }
    }
}
