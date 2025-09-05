using Ardalis.GuardClauses;

namespace MediAppoint.Patient.Domain.ValueObjects
{
    public record PatientName
    {
        public const int MaxLength = 20;
        public const int MinLength = 3;

        public string Value { get; private set; }
        private PatientName(string Value)
        {
            this.Value = Value;
        }

        public static PatientName Create(string name)
        {
            Guard.Against.NullOrEmpty(name);
            Guard.Against.NullOrWhiteSpace(name);
            Guard.Against.InvalidInput(name, nameof(name), _ => _.Length <= MaxLength);
            Guard.Against.InvalidInput(name, nameof(name), _ => _.Length >= MinLength);
            return new PatientName(name);
        }
    }
}