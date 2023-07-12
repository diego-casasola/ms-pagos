using Domain.Pagos.Event;
using MassTransit;
using MediatR;
using Shared.Core;

namespace Application.Pagos.UseCases.DomainEventHandler
{
    public class PublishingIntegrationEventWhenDonacionCompletadaHandler : INotificationHandler<ConfirmedDomainEvent<DonacionCompletada>>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public PublishingIntegrationEventWhenDonacionCompletadaHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task Handle(ConfirmedDomainEvent<DonacionCompletada> notification, CancellationToken cancellationToken)
        {
            Shared.IntegrationEvents.DonacionCompletada evento = new Shared.IntegrationEvents.DonacionCompletada()
            {
                DonacionId = notification.DomainEvent.PagoId,
                ProyectoId = notification.DomainEvent.ProyectoId,
            };
            await _publishEndpoint.Publish<Shared.IntegrationEvents.DonacionCompletada>(evento);
        }
    }
}
