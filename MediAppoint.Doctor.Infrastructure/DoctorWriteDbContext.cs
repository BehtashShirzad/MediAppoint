using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Contracts;
using SharedKernel.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MediAppoint.Doctor.Infrastructure
{
    internal class DoctorWriteDbContext:DbContext
    {
        readonly IDomainEventsDispatcher domainEventsDispatcher;
        public DoctorWriteDbContext(DbContextOptions<DoctorWriteDbContext> options,
    IDomainEventsDispatcher DomainEventsDispatcher)
        : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            domainEventsDispatcher = DomainEventsDispatcher;
        }

        public DbSet<Doctor.Domain.Core.Doctor> Doctors => Set<Domain.Core.Doctor>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var res = await base.SaveChangesAsync(cancellationToken);
            await PublishDomainEventsAsync();
            return res;
        }

        private async Task PublishDomainEventsAsync()
        {
            var domainEntities = ChangeTracker
        .Entries()
        .Select(e => e.Entity)
        .OfType<IAggregateRoot>()
        .Where(e => e.DomainEvents.Any())
        .ToList();

            var domainEvents = domainEntities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            domainEntities.ForEach(e => e.ClearEvents());

            await domainEventsDispatcher.DispatchAsync(domainEvents, Doctor.Application.ApplicationAssemblyReference.Assembly);
        }
    }
}
