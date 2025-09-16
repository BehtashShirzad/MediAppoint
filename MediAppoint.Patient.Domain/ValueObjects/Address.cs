using Ardalis.GuardClauses;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Domain.ValueObjects
{
    public class Address: BaseAddress
    {
        protected override IEnumerable<object> GetMemberValues()
        {
            yield return Country;
            yield return State;
            yield return City;
            yield return Address1;
            yield return Address2;
            yield return ZipCode;
        }
        public Address(string country, State state, string city, string address1, string address2, string zipCode):base(country,state,city,address1,address2,zipCode)
        {
            
        }
        public static Address Create(string country, State state, string city, string address1, string address2, string zipCode)
        {

            Guard.Against.NullOrEmpty(country);
            Guard.Against.NullOrEmpty(city);
            Guard.Against.NullOrEmpty(address1);
            Guard.Against.NullOrEmpty(zipCode);

            return new Address(country, state, city, address1, address2, zipCode);
        }
    }
}
