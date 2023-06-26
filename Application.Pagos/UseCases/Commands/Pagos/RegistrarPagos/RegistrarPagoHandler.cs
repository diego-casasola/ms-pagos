using Domain.Pagos.Model.Pago;
using Domain.Pagos.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagos.UseCases.Commands.Pagos.RegistrarPagos
{
    internal class RegistrarPagoHandler : IRequestHandler<RegistrarPagoCommand, Guid>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarPagoHandler(IPagoRepository pagoRepository, IUnitOfWork unitOfWork)
        {
            _pagoRepository = pagoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(RegistrarPagoCommand request, CancellationToken cancellationToken)
        {
            Pago pago = new Pago(request.IdPago, request.Monto, request.Estado);
            await _pagoRepository.CreateAsync(pago);
            await _unitOfWork.Commit();
            return pago.Id;
        }
    }
}
