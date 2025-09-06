using SharedKernel.Domain;

namespace MediAppoint.Patient.Application.IntegrationEvents
{
    public record RegisteredNotificationEvent(Guid Id) : DomainEvent;

}