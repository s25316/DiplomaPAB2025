// Ignore Spelling: Regon

// Ignore Spelling: Regon
using REGON.Exceptions;

namespace REGON.ValueObjects
{
    internal readonly record struct UserKey
    {
        // Properties
        public readonly string Value { get; }


        // Constructor
        public UserKey(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new RegonKeyException(Messages.Empty_UserKey);
            }
            Value = value.Trim();
        }


        // Methods
        public static implicit operator UserKey(string value) => new(value);
        public static implicit operator string(UserKey value) => value.Value;
        public override string ToString() => Value;
    }
}
