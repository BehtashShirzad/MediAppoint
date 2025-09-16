using MediAppoint.Doctor.Domain.Core;
using MediAppoint.Doctor.Domain.ValueObjects;
using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Domain.Contracts
{
    public interface IDoctorWriteRepository:IRepository<Domain.Core.Doctor, DoctorId>
    {
    }
}
