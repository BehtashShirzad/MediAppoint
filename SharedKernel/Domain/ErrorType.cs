using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    public record ErrorType : SmartEnum
    {
        public static readonly ErrorType Failure = new ErrorType(1, nameof(Failure));
        public static readonly ErrorType Validation = new ErrorType(2, nameof(Validation));
        public static readonly ErrorType Problem = new ErrorType(3, nameof(Problem));
        public static readonly ErrorType NotFound = new ErrorType(4, nameof(NotFound));
        public static readonly ErrorType Conflict = new ErrorType(5, nameof(Conflict));

        private ErrorType(int value, string name)
            : base(value, name) { }
    }
}
