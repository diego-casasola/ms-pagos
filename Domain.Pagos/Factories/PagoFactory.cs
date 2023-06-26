using Domain.Pagos.Model.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Factories
{
    public class PagoFactory : IPagoFactory
    {
        public Pago CrearPago()
        {
            return new Pago();
        }

        public Pago CrearPago(Guid idPago, float monto, int estado)
        {
            if (idPago == null || monto == null)
            {
                return new Pago();
            }
            return new Pago(idPago, monto, estado);
        }
    }
}
