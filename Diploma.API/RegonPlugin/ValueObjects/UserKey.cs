// Ignore Spelling: Regon, Plugin
using RegonPlugin.Exceptions;

namespace RegonPlugin.ValueObjects
{
    internal readonly record struct UserKey
    {
        public readonly string Value { get; }


        public UserKey(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new RegonKeyException(Messages.Empty_UserKey);
            }
            Value = value.Trim();
        }


        public static implicit operator UserKey(string value) => new(value);
        public static implicit operator string(UserKey value) => value.Value;
        public override string ToString() => Value;
    }
}
