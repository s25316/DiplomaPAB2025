// Ignore Spelling: Regon, Plugin, Krs
using RegonPlugin.Exceptions;
using RegonPlugin.Providers;
using System.Text.RegularExpressions;

namespace RegonPlugin.ValueObjects
{
    internal readonly record struct Krs
    {
        // 10 digits contains KRS in Poland
        private static readonly Regex _regex = new Regex(@"^\d{10}$");

        public readonly string Value { get; }


        public Krs(string value)
        {
            value = CustomStringProvider.ExtractDigits(value);
            if (!_regex.IsMatch(value))
            {
                throw new RegonInvalidInputDataException($"{Messages.Invalid_Krs} {Messages.YourValue}: {value}.");
            }
            Value = value;
        }


        public static implicit operator Krs(string value) => new(value);
        public static implicit operator string(Krs value) => value.Value;
        public override string ToString() => Value;
    }
}
