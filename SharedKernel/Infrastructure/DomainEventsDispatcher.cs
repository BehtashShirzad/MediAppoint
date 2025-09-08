 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SharedKernel.Domain.Contracts;
using SharedKernel.Infrastructure.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure
{
    internal sealed class DomainEventsDispatcher(
      IServiceProvider serviceProvider,
      IDomainEventHandlersFactory domainEventHandlersFactory
  ) : IDomainEventsDispatcher
    {
        public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents,Assembly assembly, CancellationToken cancellationToken = default)
        {
            using var scope = serviceProvider.CreateScope(); // <-- ایجاد scope
            var scopedProvider = scope.ServiceProvider;

            foreach (var domainEvent in domainEvents)
            {
                // resolve handlers از داخل scope
                var handlers = domainEventHandlersFactory.GetHandlers(
                    domainEvent.GetType(),
                    scopedProvider,
                    assembly
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


