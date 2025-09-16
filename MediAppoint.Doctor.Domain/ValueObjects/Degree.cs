using CSharpFunctionalExtensions;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Domain.ValueObjects
{
    public record Degree : SmartEnum
    {
       
        private Degree(int value,string name) : base(value,name)
        {
        }

        public static readonly Degree GeneralPractitioner =
      new Degree(1, nameof(GeneralPractitioner));

        // 2. Specialty
        public static readonly Degree Specialist_InternalMedicine =
            new Degree(2, nameof(Specialist_InternalMedicine));

        public static readonly Degree Specialist_Surgery =
            new Degree(3, nameof(Specialist_Surgery));

        public static readonly Degree Specialist_Pediatrics =
            new Degree(4, nameof(Specialist_Pediatrics));

        // 3. Subspecialty
        public static readonly Degree Subspecialist_Cardiology =
            new Degree(5, nameof(Subspecialist_Cardiology));

        public static readonly Degree Subspecialist_Gastroenterology =
            new Degree(6, nameof(Subspecialist_Gastroenterology));

        public static readonly Degree Subspecialist_Neurosurgery =
            new Degree(7, nameof(Subspecialist_Neurosurgery));

    
    }
}
