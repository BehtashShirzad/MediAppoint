using MediAppoint.Doctor.Domain.ValueObjects;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Domain.Events
{
    public record DoctorCreatedDomainEvent(Guid DoctorId): DomainEvent;
     
}
