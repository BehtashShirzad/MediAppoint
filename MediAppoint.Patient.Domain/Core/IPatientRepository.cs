using MediAppoint.Patient.Domain.ValueObjects;
using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Domain.Core
{
    public interface IPatientRepository:IRepository<Patient,PatientId>
    {
    }
}
