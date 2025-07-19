// Ignore Spelling: Regon, Plugin
using RegonPlugin.Exceptions;
using RegonPlugin.Providers;
using System.Text.RegularExpressions;

namespace RegonPlugin.ValueObjects
{
    internal readonly record struct Regon
    {
        // Or 9 Or 14 digits contains REGON in Poland
        private static readonly Regex _regex = new Regex(@"^(\d{9}|\d{14})$");

        public readonly string Value { get; }


        public Regon(string value)
        {
            value = CustomStringProvider.ExtractDigits(value);
            if (!_regex.IsMatch(value))
            {
                throw new RegonInvalidInputDataException($"{Messages.Invalid_Regon} {Messages.YourValue}: {value}.");
            }
            Value = value;
        }


        public static implicit operator Regon(string value) => new(value);
        public static implicit operator string(Regon value) => value.Value;
        public override string ToString() => Value;
    }
}
