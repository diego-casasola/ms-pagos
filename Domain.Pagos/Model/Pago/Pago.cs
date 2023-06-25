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
        public Guid IdPago { get; private set; }
        public Decimal Monto { get; private set; }
        internal Pago(Guid idPago, Decimal monto)
        {
            Id = idPago;
            Monto = monto;
        }

        internal Pago()
        {

        }
    }
}
