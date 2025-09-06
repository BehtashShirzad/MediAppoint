using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Domain.ValueObjects
{
    public class State : ValueObject
    {
        public string Code { get; }
        public string Name { get; }

        private State(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public static State Create(string code, string name) => new(code, name);

        protected override IEnumerable<object> GetMemberValues()
        {
            yield return Code;
            yield return Name;
        }
    }

}
