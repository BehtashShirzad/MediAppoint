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
    public class QuerySqlRepository:SqlRepository<Patient.Domain.Core.Patient,PatientId>, IPatientQueryRepository
    {
        public QuerySqlRepository(PatientReadContext context):base(context)
        {
            
        }
    }
}
