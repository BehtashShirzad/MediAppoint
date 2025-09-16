using MediAppoint.Doctor.Domain.Contracts;
using MediAppoint.Doctor.Domain.ValueObjects;
using SharedKernel.Domain.Contracts;
using SharedKernel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Infrastructure
{
    internal class DoctorReadSqlRepository:SqlRepository<Doctor.Domain.Core.Doctor,DoctorId>, IDoctorQueryRepository
    {
        public DoctorReadSqlRepository(DoctorReadDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
