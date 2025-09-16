using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using MediAppoint.Doctor.Domain.Events;
using MediAppoint.Doctor.Domain.ValueObjects;
using SharedKernel.Domain;
using SharedKernel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Domain.Core
{
    public class Doctor:AggregateRoot<DoctorId>
    {
        #region Constructor
        protected Doctor() { }
        private Doctor(DoctorId Id,string username,Name name,List<Address> address,NationalCode nationalCode,List<Degree> degrees) 
        {
            Name = name;
            UserName = username;
            _addresses = address ?? new List<Address>();
            Code=nationalCode;
            Degrees = degrees;

        }
        #endregion

        #region Fields
        public Name Name { get; set; }
        public string UserName { get; set; }
        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        public NationalCode Code { get; private set; }
        public List<Degree> Degrees { get; private set; }

        public static Doctor Create(DoctorId doctorId, string UserName, string name, string natioanlCode, List<Address> address,List<string> DegreesStr)
        {

            Guard.Against.NullOrEmpty(DegreesStr);
            var nameD = Name.Create(name);
            List<Degree> degrees = new List<Degree>();
            foreach (var item in DegreesStr)
            {
                var degreeResult = Degree.FromName<Degree>(item);
                Guard.Against.Expression(_ => degreeResult.IsFailure, degreeResult, degreeResult.Error);
                degrees.Add(degreeResult.Value);

            }
            var code = NationalCode.Create(natioanlCode);
            var doctor = new Doctor(doctorId, UserName, nameD, address, code,degrees);

            doctor.RaiseEvent(new DoctorCreatedDomainEvent(doctorId.Value));
            return doctor;

        }
        #endregion
    }
}
