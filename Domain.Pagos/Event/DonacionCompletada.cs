using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Event
{
    public record DonacionCompletada : DomainEvent
    {
        public Guid PagoId { get; private set; }
        public Guid ProyectoId { get; private set; }

        public DonacionCompletada(Guid pagoId, Guid proyectoId) : base(DateTime.Now)
        {
            PagoId = pagoId;
            ProyectoId = proyectoId;
        }
    }
}
