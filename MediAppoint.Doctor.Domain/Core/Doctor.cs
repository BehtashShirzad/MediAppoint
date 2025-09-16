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
        private Doctor(DoctorId Id,string username,Name name,List<Address> address,NationalCode nationalCode, Degree degree) 
        {
            Name = name;
            UserName = username;
            _addresses = address ?? new List<Address>();
            Code=nationalCode;
            Degree = degree;

        }
        #endregion

        #region Fields
        public Name Name { get; set; }
        public string UserName { get; set; }
        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        public NationalCode Code { get; private set; }
        public  Degree  Degree { get; private set; }
        #endregion

        public static Doctor Create(DoctorId doctorId, string UserName, string name, string natioanlCode, List<Address> address, string DegreeStr)
        {

            Guard.Against.NullOrEmpty(DegreeStr);
            var nameD = Name.Create(name);
            var degreeResult = Degree.FromName<Degree>(DegreeStr);
            Guard.Against.Expression(_ => degreeResult.IsFailure, degreeResult, degreeResult.Error);
       
            var code = NationalCode.Create(natioanlCode);
            var doctor = new Doctor(doctorId, UserName, nameD, address, code, degreeResult.Value);

            doctor.RaiseEvent(new DoctorCreatedDomainEvent(doctorId.Value));
            return doctor;

        }

        public void UpdateAddress(List<Address> address)
        {
            Guard.Against.Null(address, nameof(address));
            _addresses.Clear();
            _addresses.AddRange(address);
        }

        public void UpdateFullName(string name)
        {
            var patientName = Name.Create(name);

            Name = patientName;
        }

        public void UpdateUserName(string username)
        {
            UserName = username;


        }
    
    }
}
