﻿

using Application.Pagos.UseCases.Commands.Pagos.RegistrarPagos;
using MassTransit;
using MediatR;
using Shared.IntegrationEvents;

namespace Application.Pagos.UseCases.Consumers
{
    public class DonacionCreadaConsumer : IConsumer<DonacionCreada>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "donacion-creada-exchange";
        public const string QueueName = "donacion-creada-proyectos";

        public DonacionCreadaConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Consume(ConsumeContext<DonacionCreada> context)
        {
            int monto = (int)context.Message.Monto;
            context.Message.Monto = monto;
            DonacionCreada @event = context.Message;
            System.Diagnostics.Debug.WriteLine($"DonacionCreadaConsumer: {monto}");
            RegistrarPagoCommand command = new RegistrarPagoCommand(@event.DonacionId, @event.ProyectoId, @event.Monto);
            return _mediator.Send(command);
        }
    }
}
