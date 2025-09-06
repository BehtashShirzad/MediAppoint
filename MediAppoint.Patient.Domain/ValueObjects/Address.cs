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
    public class Address:ValueObject
    {
        public string Country { get; init; }
        public State State { get; init; }
        public string City { get; init; }
        public string Address1 { get; init; }
        public string Address2 { get; init; }
        public string ZipCode { get; init; }

        private Address()
        {
            
        }
        private Address(string country, State state, string city, string address1, string address2, string zipCode)
        {
            Country = country;
            State = state;
            City = city;
            Address1 = address1;
            Address2 = address2;
            ZipCode = zipCode;
        }

        public static Address Create(string country, State state,string city,string address1,string address2,string zipCode)
        {
            Guard.Against.NullOrEmpty(country);
            Guard.Against.NullOrEmpty(city);
            Guard.Against.NullOrEmpty(address1);
            Guard.Against.NullOrEmpty(zipCode);
            return new Address(country,state,city,address1,address2,zipCode); 
        }
        protected override IEnumerable<object> GetMemberValues()
        {
            yield return Country;
            yield return State;
            yield return City;
            yield return Address1;
            yield return Address2;
            yield return ZipCode;
        }
    }
}
