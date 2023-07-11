using Domain.Pagos.Event;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Model.Pago
{
    public class Pago : AggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid ProyectoId { get; private set; }
        public float Monto { get; private set; }
        //estado de pago
        public int Estado { get; private set; }
        public Pago(Guid idPago, Guid proyectoId, float monto, int estado)
        {
            Id = idPago;
            ProyectoId = proyectoId;
            Monto = monto;
            Estado = estado;
        }

        public void EditPago(float monto, int estado)
        {
            Monto = monto;
            Estado = estado;
        }

        public void Pagar()
        {
            Estado = 1;
            AddDomainEvent(new PagoCompletado(pagoId: Id, proyectoId: ProyectoId, monto: Monto, estado: Estado));
        }

        public Pago()
        {

        }
    }
}
