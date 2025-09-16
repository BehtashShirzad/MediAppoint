using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Doctor.Domain.ValueObjects
{
    public class Address
    {
        //Doctors Have their work Address or Home Address
            public bool? IsHomeAddress { get; set; } =false;
    }
}
