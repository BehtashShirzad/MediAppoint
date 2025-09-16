using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    public record Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error NullValue =
            new("Error.NullValue", "The specified result value is null.", ErrorType.Failure);

        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        private const string Separator = ":";

        public Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public static implicit operator string(Error error) => error.Code;

        public override string ToString() => $"{Type.Name}{Separator}{Code}{Separator}{Description}";

        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);

        public static Error Validation(string code, string description) =>
            new(code, description, ErrorType.Validation);

        public static Error Problem(string code, string description) =>
            new(code, description, ErrorType.Problem);

        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error Conflict(string code, string description) =>
            new(code, description, ErrorType.Conflict);
    }
}
