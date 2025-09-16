
using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Infrastructure
{
    internal sealed class UnitOfWork(DoctorWriteDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        =>
        context.SaveChangesAsync(cancellationToken);
    }
}
