using Ardalis.GuardClauses;

namespace SharedKernel.Domain.ValueObjects
{
    public record Name
    {
        public const int MaxLength = 20;
        public const int MinLength = 3;

        public string Value { get; private set; }
        private Name(string Value)
        {
            this.Value = Value;
        }

        public static Name Create(string name)
        {
            Guard.Against.NullOrEmpty(name);
            Guard.Against.NullOrWhiteSpace(name);
            Guard.Against.InvalidInput(name, nameof(name), _ => _.Length <= MaxLength);
            Guard.Against.InvalidInput(name, nameof(name), _ => _.Length >= MinLength);
            return new Name(name);
        }
    }
}