// Ignore Spelling: Regon, Plugin
namespace RegonPlugin
{
    internal sealed class Optional<T>
    {
        public bool IsNull { get; }
        public T? Value { get; }


        private Optional(bool isNull, T? value)
        {
            IsNull = isNull;
            Value = value;
        }


        public static Optional<T> Some(T value)
        {
            return new Optional<T>(false, value);
        }

        public static Optional<T> None()
        {
            return new Optional<T>(true, default);
        }
    }
}
