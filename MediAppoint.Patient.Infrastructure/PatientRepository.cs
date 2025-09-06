using MediAppoint.Patient.Domain.Core;
using MediAppoint.Patient.Domain.ValueObjects;
using SharedKernel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Infrastructure
{
    internal class PatientRepository: SqlRepository<Patient.Domain.Core.Patient,PatientId>,IPatientRepository
    {
        public PatientRepository(PatientWriteContext writeContext):base(writeContext) { }
        
    }
}
