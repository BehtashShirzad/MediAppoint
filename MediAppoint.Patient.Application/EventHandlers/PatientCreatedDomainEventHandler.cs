using MediAppoint.Patient.Domain.Events;
using SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application.EventHandlers
{
    public class PatientCreatedDomainEventHandler : DomainEventHandler<PatientCreatedDomainEvent>
    {
        private readonly IEventBus _eventBus;

        public PatientCreatedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        

        public override async Task Handle(PatientCreatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            await _eventBus.PublishAsync(domainEvent);
        }
    }
}
