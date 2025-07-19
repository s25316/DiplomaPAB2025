// Ignore Spelling: Regon, Plugin
using RegonPlugin.Exceptions;
using RegonPlugin.Providers;
using System.Text.RegularExpressions;

namespace RegonPlugin.ValueObjects
{
    internal readonly record struct Nip
    {
        // 10 digits contains NIP in Poland
        private static readonly Regex _regex = new Regex(@"^\d{10}$");

        public readonly string Value { get; }


        public Nip(string value)
        {
            value = CustomStringProvider.ExtractDigits(value);
            if (!_regex.IsMatch(value))
            {
                throw new RegonInvalidInputDataException($"{Messages.Invalid_Nip} {Messages.YourValue}: {value}.");
            }
            Value = value;
        }


        public static implicit operator Nip(string value) => new(value);
        public static implicit operator string(Nip value) => value.Value;
        public override string ToString() => Value;
    }
}
