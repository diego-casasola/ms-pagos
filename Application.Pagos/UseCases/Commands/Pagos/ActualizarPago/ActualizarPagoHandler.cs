using Domain.Pagos.Model.Pago;
using Domain.Pagos.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagos.UseCases.Commands.Pagos.ActualizarPago
{
    internal class ActualizarPagoHandler : IRequestHandler<ActualizarPagoCommand, Guid>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ActualizarPagoHandler(IPagoRepository pagoRepository, IUnitOfWork unitOfWork)
        {
            _pagoRepository = pagoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(ActualizarPagoCommand request, CancellationToken cancellationToken)
        {
            Pago pago = await _pagoRepository.FindByIdAsync(request.IdPago);
            pago.Pagar();
            await _pagoRepository.UpdateAsync(pago);
            await _unitOfWork.Commit();
            return pago.Id;
        }
    }
    }
    
