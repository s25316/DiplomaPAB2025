// Ignore Spelling: Regon, Plugin
namespace RegonPlugin.Models.Generics
{
    internal sealed record Optional<T>
    {
        public bool IsNullOrEmpty { get; init; }
        public T Value { get; init; }


        public static Optional<T> Some(T value)
        {
            return new Optional<T>
            {
                IsNullOrEmpty = false,
                Value = value
            };
        }

        public static Optional<T> None()
        {
            return new Optional<T>
            {
                IsNullOrEmpty = true,
            };
        }
    }
}
