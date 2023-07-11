using Domain.Pagos.Event;
using MassTransit;
using MediatR;
using ShareKernel.Core;

namespace Application.Pagos.UseCases.DomainEventHandler
{
    public class PublishingIntegrationEventWhenDonacionCompletadaHandler : INotificationHandler<ConfirmedDomainEvent<PagoCompletado>>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public PublishingIntegrationEventWhenDonacionCompletadaHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task Handle(ConfirmedDomainEvent<PagoCompletado> notification, CancellationToken cancellationToken)
        {
            SharedKernel.IntegrationEvents.DonacionCreada evento = new SharedKernel.IntegrationEvents.DonacionCreada()
            {
                DonacionId = notification.DomainEvent.PagoId,
                ProyectoId = notification.DomainEvent.ProyectoId,
                Monto = notification.DomainEvent.Monto,
                Estado = notification.DomainEvent.Estado
            };
            await _publishEndpoint.Publish<SharedKernel.IntegrationEvents.DonacionCreada>(evento);
        }
    }
}
