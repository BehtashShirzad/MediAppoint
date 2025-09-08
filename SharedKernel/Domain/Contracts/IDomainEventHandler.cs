using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Contracts
{
    public interface IDomainEventHandler
    {
        Task Handle(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }

    public interface IDomainEventHandler<in TDomainEvent> : IDomainEventHandler
        where TDomainEvent : IDomainEvent
    {
        Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
