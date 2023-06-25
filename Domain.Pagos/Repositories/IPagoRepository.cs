using Domain.Pagos.Model.Pago;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Repositories
{
    public interface IPagoRepository : IRepository<Pago, Guid>
    {
    }
}
