using MediAppoint.Patient.Infrastructure.Configuration;

using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MediAppoint.Patient.Infrastructure
{
    public class PatientWriteContext:DbContext
    {
        readonly IDomainEventsDispatcher domainEventsDispatcher;
        public PatientWriteContext(DbContextOptions<PatientWriteContext> options,
    IDomainEventsDispatcher DomainEventsDispatcher)
        : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            domainEventsDispatcher = DomainEventsDispatcher;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

        }

        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            var res =    await base.SaveChangesAsync(cancellationToken);
            await PublishDomainEventsAsync();
            return res;
        }
        public DbSet<Patient.Domain.Core.Patient> Patients => Set<Domain.Core.Patient>();
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

            await domainEventsDispatcher.DispatchAsync(domainEvents);
        }
    }
}
