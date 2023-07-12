using Domain.Pagos.Event;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Model.Pago
{
    public class Pago : AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public Guid ProyectoId { get; private set; }
        public decimal Monto { get; private set; }
        //estado de pago
        public int Estado { get; private set; }
        public Pago(Guid idPago, Guid proyectoId, decimal monto, int estado)
        {
            Id = idPago;
            ProyectoId = proyectoId;
            Monto = monto;
            Estado = estado;
        }

        public void EditPago(decimal monto, int estado)
        {
            Monto = monto;
            Estado = estado;
        }

        public void Pagar()
        {
            Estado = 1;
            AddDomainEvent(new DonacionCompletada(pagoId: Id, proyectoId: ProyectoId));
        }

        public Pago()
        {

        }
    }
}
