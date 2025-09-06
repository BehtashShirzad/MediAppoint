using MediAppoint.Patient.Domain.Events;
using SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.EventHandlers
{
    public class PatientUpdatedDomainEventHandler (IEventBus eventBus): DomainEventHandler<PatientUpdatedDomainEvent>
    {
        public override async Task Handle(PatientUpdatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            await eventBus.PublishAsync(domainEvent);
        }
    }
}
