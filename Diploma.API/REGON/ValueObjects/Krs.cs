// Ignore Spelling: Regon, Krs
using REGON.Exceptions;
using REGON.Providers;
using System.Text.RegularExpressions;

namespace REGON.ValueObjects
{
    internal readonly record struct Krs
    {
        // Fields
        // 10 digits contains KRS in Poland
        private static readonly Regex _regex = new Regex(@"^\d{10}$");

        // Properties
        public readonly string Value { get; }


        // Constructor
        public Krs(string value)
        {
            value = CustomStringProvider.ExtractDigits(value);
            if (!_regex.IsMatch(value))
            {
                throw new RegonClientException(
                    $"{Messages.Krs_Invalid} {Messages.YourValue}: {value}",
                    ExceptionType.InputData
                    );
            }
            Value = value;
        }


        // Methods
        public static implicit operator Krs(string value) => new(value);
        public static implicit operator string(Krs value) => value.Value;
        public override string ToString() => Value;
    }
}
