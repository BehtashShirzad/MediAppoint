using MediAppoint.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Infrastructure
{
    internal sealed class UnitOfWork(PatientWriteContext context) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        =>
        context.SaveChangesAsync(cancellationToken);
    }
}
