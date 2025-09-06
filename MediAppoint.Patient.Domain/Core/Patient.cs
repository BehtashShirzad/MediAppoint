using Ardalis.GuardClauses;
using MediAppoint.Patient.Domain.Events;
using MediAppoint.Patient.Domain.ValueObjects;
using MediAppoint.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Domain.Core
{
    public class Patient:AggregateRoot<PatientId>
    {
        #region Constructor
        protected Patient() { }
        private  Patient(PatientId patientId,PatientName name, List<Address> address, NationalCode natioanlCode)
        {
            this.Id = patientId;
            this.Name = name;
            _addresses = address ?? new List<Address>();
            this.Code = natioanlCode;
        }
        #endregion Constructor

        #region Fields
        public   PatientName Name { get;private set; }
        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        public NationalCode Code { get;private set; }
        #endregion Fields

        #region Methods
        public static Patient Create(PatientId patientId,string name,string natioanlCode, List<Address>  address)
        {

           var patientName = PatientName.Create(name);
          
            var code = NationalCode.Create(natioanlCode);
            var patient =  new Patient(patientId, patientName, address, code);
            
            patient.RaiseEvent(new PatientCreatedDomainEvent(patientId.Value));
            return patient;

        }
        public  void UpdateAddress(List<Address> address)
        {
            Guard.Against.Null(address,nameof(address));
            _addresses.Clear();          // آدرس‌های قدیمی پاک می‌شن
            _addresses.AddRange(address);
        }
        #endregion Methods
    }
}
