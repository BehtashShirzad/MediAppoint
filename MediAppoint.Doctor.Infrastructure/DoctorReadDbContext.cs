using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Infrastructure
{
    public class DoctorReadDbContext:DbContext
    {
        public DoctorReadDbContext(DbContextOptions<DoctorReadDbContext> options)
    : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());

        }
        public IQueryable<Domain.Core.Doctor> Patients => Set<Domain.Core.Doctor>().AsQueryable();

    }
}
