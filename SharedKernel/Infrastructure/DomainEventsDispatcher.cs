 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SharedKernel.Domain;
using SharedKernel.Infrastructure;
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

    //public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    //{

    //    var domainEventHandlers = domainEventHandlersFactory.GetHandlers(
    //        domainEvent.GetType(),
    //        serviceProvider,
    //       ApplicationAssemblyReference.Assembly

    //    );

    //    foreach (var domainEventHandler in domainEventHandlers)
    //    {
    //        var policy = CreateRetryPolicy(
    //        options.Value.RetryCount,
    //            options.Value.SleepDuration
    //        );
    //        var result = await policy.ExecuteAndCaptureAsync(
    //            () => domainEventHandler.Handle(domainEvent, context.CancellationToken)
    //        );

    //        message.Error = result?.FinalException?.Message;
    //        message.ProcessedOn = DateTime.UtcNow;
    //    }
    //    //foreach (var domainEvent in domainEvents)
    //    //{
    //    //    using var scope = _serviceProvider.CreateScope();

    //    //    var domainEventType = domainEvent.GetType();
    //    //    var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEventType);

    //    //    var handlers = scope.ServiceProvider.GetServices(handlerType);

    //    //    foreach (var handler in handlers)
    //    //    {
    //    //        if (handler == null) continue;

    //    //        var method = handlerType.GetMethod("Handle")
    //    //                     ?? throw new InvalidOperationException($"Handler {handler.GetType().Name} has no Handle method");

    //    //        // Call Handle(domainEvent, cancellationToken)
    //    //        var task = (Task)method.Invoke(handler, new object[] { domainEvent, cancellationToken })!;
    //    //        await task;
    //    //    }
    //    //}
    //}
}


