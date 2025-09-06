using MediAppoint.Patient.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Infrastructure.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Domain.Core.Patient>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.Patient> builder)
        {
            builder.ToTable("Patients");

            // Primary Key
            builder.HasKey(p => p.Id);

            // PatientId as Value Object
            builder.Property(p => p.Id)
                   .HasConversion(
                        v => v.Value,             // from PatientId -> Guid
                        v => new PatientId(v));   // from Guid -> PatientId

            // PatientName as Owned Value Object
            builder.OwnsOne(p => p.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("Name")
                    .HasMaxLength(PatientName.MaxLength)
                    .IsRequired();
            });

            // NationalCode as Owned Value Object
            builder.OwnsOne(p => p.Code, code =>
            {
                code.Property(c => c.Code)
                    .HasColumnName("NationalCode")
                    .HasMaxLength(10)
                    .IsRequired();
            });

            // Address as Owned Value Object
            builder.OwnsMany(p => p.Addresses, address =>
            {
                address.ToTable("PatientAddresses");  

                address.WithOwner().HasForeignKey("PatientId");

                address.Property(a => a.Country).HasMaxLength(20).IsRequired();
                address.Property(a => a.City).HasMaxLength(20).IsRequired();
                address.Property(a => a.Address1).HasMaxLength(100).IsRequired();
                address.Property(a => a.Address2).HasMaxLength(100);
                address.Property(a => a.ZipCode).HasMaxLength(20).IsRequired();

                address.OwnsOne(a => a.State, state =>
                {
                    state.Property(s => s.Code).HasMaxLength(10).IsRequired();
                    state.Property(s => s.Name).HasMaxLength(20).IsRequired();
                });

                // Primary Key برای هر آدرس
                address.Property<Guid>("Id");
                address.HasKey("Id");
            });
        }
    }
}
