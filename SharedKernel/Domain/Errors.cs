using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SharedKernel.Domain
{
    internal class Errors
    {
        protected Errors() { }

        public static Error InvalidEnumValueError<T>(int value)
            where T : SmartEnum =>
            Error.Validation($"{typeof(T).Name}.Validation", $"Value ({value}) is not valid");

        public static Error InvalidEnumNameError<T>(string name)
            where T : SmartEnum =>
            Error.Validation($"{typeof(T).Name}.Validation", $"Name ({name}) is not a valid");
    }
}
