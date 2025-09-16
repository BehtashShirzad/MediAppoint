using Ardalis.GuardClauses;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Domain.ValueObjects
{
    public class Address:BaseAddress
    {
        //Doctors Have their work Address or Home Address
            public bool IsHomeAddress { get; set; } =false;
        protected Address() { }

        public Address(string country, State state,
            string city, string address1, string address2,
            string zipCode,bool isHomeAddress= false) : base(country, state, city, address1,
                address2, zipCode)
        {
            IsHomeAddress= isHomeAddress;
        }

        public static Address Create(string country, State state, string city, string address1, string address2, string zipCode)
        {

            Guard.Against.NullOrEmpty(country);
            Guard.Against.NullOrEmpty(city);
            Guard.Against.NullOrEmpty(address1);
            Guard.Against.NullOrEmpty(zipCode);

            return new Address(country, state, city, address1, address2, zipCode);
        }

        protected override IEnumerable<object> GetMemberValues()
        {
            yield return IsHomeAddress;
            yield return base.Country;
            yield return base.City; 
            yield return base.Address1;
            yield return base.Address2; 
            yield return base.State;
            yield return base.ZipCode;
        }
    }
}
