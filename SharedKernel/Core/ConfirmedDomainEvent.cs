﻿using MediatR;

namespace ShareKernel.Core
{
    public class ConfirmedDomainEvent<T> : INotification where T : DomainEvent
    {
        public T DomainEvent { get; }
        public ConfirmedDomainEvent(T domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
