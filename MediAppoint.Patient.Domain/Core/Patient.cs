using Ardalis.GuardClauses;
using MediAppoint.Patient.Domain.Events;
using MediAppoint.Patient.Domain.ValueObjects;
using SharedKernel.Domain;
using SharedKernel.Domain.ValueObjects;
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
        private  Patient(PatientId patientId,string UserName, Name name, List<Address> address, NationalCode natioanlCode)
        {
            base.Id = patientId;
            this.Name = name;
            _addresses = address ?? new List<Address>();
            this.Code = natioanlCode;
            this.UserName = UserName;
        }
        #endregion Constructor

        #region Fields
        public   Name Name { get;private set; }
        public   string UserName { get;private set; }
        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        public NationalCode Code { get;private set; }
        #endregion Fields

        #region Methods
        public static Patient Create(PatientId patientId,string UserName, string name,string natioanlCode, List<Address>  address)
        {

           var patientName = Name.Create(name);
          
            var code = NationalCode.Create(natioanlCode);
            var patient =  new Patient(patientId, UserName, patientName, address, code);
            
            patient.RaiseEvent(new PatientCreatedDomainEvent(patientId.Value));
            return patient;

        }
        public  void UpdateAddress(List<Address> address)
        {
            Guard.Against.Null(address,nameof(address));
            _addresses.Clear();         
            _addresses.AddRange(address);
        }

        public void UpdateFullName(string name)
        {
            var patientName = Name.Create(name);
                   
           Name= patientName;
        }

        public void UpdateUserName(string username)
        {
              UserName = username;

             
        }
        #endregion Methods
    }
}
