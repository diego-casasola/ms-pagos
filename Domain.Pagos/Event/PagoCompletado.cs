using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Event
{
    public record PagoCompletado : DomainEvent
    {
        public Guid PagoId { get; private set; }
        public Guid ProyectoId { get; private set; }
        public float Monto { get; private set; }
        public int Estado { get; private set; }

        public PagoCompletado(Guid pagoId, Guid proyectoId, float monto, int estado) : base(DateTime.Now)
        {
            PagoId = pagoId;
            ProyectoId = proyectoId;
            Monto = monto;
            Estado = estado;
        }
    }
}
