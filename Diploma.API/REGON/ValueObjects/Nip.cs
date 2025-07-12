// Ignore Spelling: Regon
using REGON.Exceptions;
using REGON.Providers;
using System.Text.RegularExpressions;

namespace REGON.ValueObjects
{
    internal readonly record struct Nip
    {
        // Fields
        // 10 digits contains NIP in Poland
        private static readonly Regex _regex = new Regex(@"^\d{10}$");

        // Properties
        public readonly string Value { get; }


        // Constructor
        public Nip(string value)
        {
            value = CustomStringProvider.ExtractDigits(value);
            if (!_regex.IsMatch(value))
            {
                throw new RegonClientException(
                    $"{Messages.Nip_Invalid} {Messages.YourValue}: {value}",
                    ExceptionType.InputData
                    );
            }
            Value = value;
        }


        // Methods
        public static implicit operator Nip(string value) => new(value);
        public static implicit operator string(Nip value) => value.Value;
        public override string ToString() => Value;
    }
}
