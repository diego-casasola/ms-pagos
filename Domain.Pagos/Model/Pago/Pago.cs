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
        public float Monto { get; private set; }
        //estado de pago
        public int Estado { get; private set; }
        public Pago(Guid idPago, float monto, int estado)
        {
            Id = idPago;
            Monto = monto;
            Estado = estado;
        }

        public void EditPago(float monto, int estado)
        {
            Monto = monto;
            Estado = estado;
        }

        public Pago()
        {

        }
    }
}
