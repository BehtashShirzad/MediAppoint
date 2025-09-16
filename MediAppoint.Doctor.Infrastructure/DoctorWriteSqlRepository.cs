using MediAppoint.Doctor.Domain.Contracts;
using MediAppoint.Doctor.Domain.ValueObjects;
using SharedKernel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Infrastructure
{
    internal class DoctorWriteSqlRepository:SqlRepository<Doctor.Domain.Core.Doctor,DoctorId>,IDoctorWriteRepository
    {
        public DoctorWriteSqlRepository(DoctorReadDbContext context):base(context)
        {
            
        }
    }
}
