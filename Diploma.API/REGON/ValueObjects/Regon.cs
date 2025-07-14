// Ignore Spelling: Regon
using REGON.Exceptions;
using REGON.Providers;
using System.Text.RegularExpressions;

namespace REGON.ValueObjects
{
    internal readonly record struct Regon
    {
        //Fields
        // Or 9 Or 14 digits contains REGON in Poland
        private static readonly Regex _regex = new Regex(@"^(\d{9}|\d{14})$");

        // Properties
        public readonly string Value { get; }


        // Constructor
        public Regon(string value)
        {
            value = CustomStringProvider.ExtractDigits(value);
            if (!_regex.IsMatch(value))
            {
                throw new InvalidInputDataException($"{Messages.Invalid_Regon} {Messages.YourValue}: {value}.");
            }
            Value = value;
        }


        // Methods
        public static implicit operator Regon(string value) => new(value);
        public static implicit operator string(Regon value) => value.Value;
        public override string ToString() => Value;
    }
}
