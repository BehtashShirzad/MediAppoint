using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Domain.Events
{
    public record PatientUpdatedDomainEvent(Guid Id):DomainEvent;
    
    
}
