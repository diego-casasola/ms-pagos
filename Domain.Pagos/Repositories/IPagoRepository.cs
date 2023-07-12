using Domain.Pagos.Model.Pago;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Repositories
{
    public interface IPagoRepository : IRepository<Pago, Guid>
    {
        Task UpdateAsync(Pago pago);
    }
}
