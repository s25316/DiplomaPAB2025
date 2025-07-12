// Ignore Spelling: Regon
namespace REGON.Exceptions
{
    public class RegonClientException : Exception
    {
        // Properties
        public ExceptionType Reason { get; }


        // Constructors
        public RegonClientException(string message, ExceptionType reason) : base(message)
        {
            Reason = reason;
        }
    }
}
