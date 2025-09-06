using MediAppoint.Patient.Domain.Events;
using SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.IntegrationEvents
{
    public class SendRegisteredNotificationEventHandler : DomainEventHandler<RegisteredNotificationEvent>
    {
        private readonly IEventBus _eventBus;

        public SendRegisteredNotificationEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }


        public override async Task Handle(RegisteredNotificationEvent domainEvent, CancellationToken cancellationToken = default)
        {
            await _eventBus.PublishAsync(domainEvent);
        }
    }
}
