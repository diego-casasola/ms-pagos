using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.IntegrationEvents
{
    public record DonacionCreada : IntegrationEvent
    {
        public Guid DonacionId { get; set; }
        public Guid ProyectoId { get; set; }
        public float Monto { get; set; }
        public int Estado { get; set; }
    }
}
