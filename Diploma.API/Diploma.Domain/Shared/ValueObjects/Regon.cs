// Ignore Spelling: Regon
using Diploma.Domain.Shared.Exceptions;
using System.Text.RegularExpressions;

namespace Diploma.Domain.Shared.ValueObjects
{
    public record Regon
    {
        // Or 9 Or 14 digits contains REGON in Poland
        private static readonly Regex _regex = new Regex(@"^(\d{9}|\d{14})$");

        public string Value { get; }


        public Regon(string value)
        {
            value = Regex.Replace(value, @"\D", "");
            if (!_regex.IsMatch(value))
            {
                throw new Resource.InvalidInputException(value);
            }
            Value = value;
        }


        public static implicit operator Regon(string value) => new(value);
        public static implicit operator string(Regon value) => value.Value;
        public override string ToString() => Value;
    }
}
