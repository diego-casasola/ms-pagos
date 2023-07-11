using Domain.Pagos.Model.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Factories
{
    public interface IPagoFactory
    {
        Pago CrearPago(Guid idPago, Guid proyectoId, float monto, int estado);
        Pago CrearPago();
    }
}
