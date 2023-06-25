using SharedKernel.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagos.Model.Donante
{
    public class Donante : AggregateRoot
    {
        public DonanteNameValue NombreCompleto { get; private set; }
        
        public Donante(string nombreCompleto)
        {
            Id = Guid.NewGuid();
            NombreCompleto = nombreCompleto;
        }

        public void EditDonante(string nombreDonante)
        {
            NombreCompleto = nombreDonante;
        }

        private Donante() { }
    }
}
