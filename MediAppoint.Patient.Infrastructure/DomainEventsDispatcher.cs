
using MediAppoint.Patient.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SharedKernel.Domain.Contracts;
using SharedKernel.Infrastructure.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Infrastructure
{
    internal sealed class DomainEventsDispatcher(
      IServiceProvider serviceProvider,
      IDomainEventHandlersFactory domainEventHandlersFactory
  ) : IDomainEventsDispatcher
    {
        public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
        {
            using var scope = serviceProvider.CreateScope(); // <-- ایجاد scope
            var scopedProvider = scope.ServiceProvider;

            foreach (var domainEvent in domainEvents)
            {
                // resolve handlers از داخل scope
                var handlers = domainEventHandlersFactory.GetHandlers(
                    domainEvent.GetType(),
                    scopedProvider,
                    ApplicationAssemblyReference.Assembly
                );

                foreach (var handler in handlers)
                {
                    if (handler == null) continue;

                    await handler.Handle(domainEvent, cancellationToken);
                }
            }
        }
    }
     
}


