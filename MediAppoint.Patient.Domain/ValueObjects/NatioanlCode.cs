using Ardalis.GuardClauses;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Domain.ValueObjects
{
    public class NationalCode : ValueObject
    {
        public string Code { get; init; }
        
        private NationalCode(string code)
        {
            Code = code;
        }

        public static NationalCode Create(string code)
        {
            Guard.Against.NullOrEmpty(code);

            return new NationalCode(code);

        }
        protected override IEnumerable<object> GetMemberValues()
        {
            yield return Code;
        }
    }
}
