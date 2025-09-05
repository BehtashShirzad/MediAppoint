using MediAppoint.Patient.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
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
        public PatientWriteContext(DbContextOptions<PatientWriteContext> options)
        : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Raise Events
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Patient.Domain.Core.Patient> Patients => Set<Domain.Core.Patient>();
       
    }
}
