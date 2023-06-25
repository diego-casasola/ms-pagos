using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagos.Dto
{
    public class VentaDto
    {
        public Guid PagoId { get; set; }
        public Decimal Monto { get; set; }
    }
}
