using MediAppoint.Patient.Domain.ValueObjects;
using MediAppoint.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Domain.Events
{
    internal record PatientCreatedDomainEvent(Guid Id):DomainEvent;
    
}
