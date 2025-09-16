using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    public abstract class BaseAddress: ValueObject
    {
        public string Country { get; init; }
        public State State { get; init; }
        public string City { get; init; }
        public string Address1 { get; init; }
        public string Address2 { get; init; }
        public string ZipCode { get; init; }

        protected BaseAddress()
        {

        }
        protected  BaseAddress(string country, State state, string city, string address1, string address2, string zipCode)
        {
            Country = country;
            State = state;
            City = city;
            Address1 = address1;
            Address2 = address2;
            ZipCode = zipCode;
        }

      
       
    }
}
