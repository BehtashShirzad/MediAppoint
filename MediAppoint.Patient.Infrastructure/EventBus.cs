using MassTransit;

using SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Infrastructure
{
    internal class EventBus (IBus bus): IEventBus
    {
        public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellation = default) where TEvent : class
        {
          await  bus.Publish(@event, cancellation);
        }
    }
}
