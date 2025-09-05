
using MediAppoint.Patient.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Infrastructure
{
    public class PatientReadContext:DbContext
    {
        public PatientReadContext(DbContextOptions<PatientReadContext> options)
       : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

        }
        public IQueryable<Domain.Core.Patient> Patients => Set<Domain.Core.Patient>().AsQueryable();
   
    }
}
