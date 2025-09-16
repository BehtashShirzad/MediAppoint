using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    public abstract record SmartEnum
    {
         
            public int Value { get; }
            public string Name { get; }

            public override string ToString() => Name;

            public override int GetHashCode() => Value.GetHashCode() ^ 31;

            protected SmartEnum() => (Value, Name) = (0, string.Empty);

            protected SmartEnum(int value, string name)
            {
                Guard.Against.NegativeOrZero(value);
                Guard.Against.NullOrEmpty(name);
                Guard.Against.NullOrWhiteSpace(name);

                (Value, Name) = (value, name);
            }

            public static IEnumerable<T> GetAll<T>()
                where T : SmartEnum =>
                typeof(T)
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Select(f => f.GetValue(null))
                    .Cast<T>();

            public static Result<T> FromValue<T>(int value)
                where T : SmartEnum
        {
                var item = GetAll<T>().FirstOrDefault(e => e.Value == value);
                return item is null
                    ? Result.Failure<T>(Errors.InvalidEnumValueError<T>(value))
                    : Result.Success(item);
            }

            public static Result<T> FromName<T>(string name)
                where T : SmartEnum
        {
                var item = GetAll<T>().FirstOrDefault(e => e.Name.Equals(name));
                return item is null
                    ? Result.Failure<T>(Errors.InvalidEnumNameError<T>(name))
                    : Result.Success(item);
            }
         
    }
}
