using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagos.Dto
{
    public class PagoDto
    {
        public Guid IdPago { get; set; }
        public float Monto { get; set; }
        public int Estado { get; set; }
    }
}
