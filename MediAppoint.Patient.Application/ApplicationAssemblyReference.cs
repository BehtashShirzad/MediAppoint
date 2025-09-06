using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MediAppoint.Patient.Application
{
    public static class ApplicationAssemblyReference
    {
        public static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
