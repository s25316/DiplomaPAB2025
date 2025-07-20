// Ignore Spelling: Regon, Plugin, Deserialization
namespace RegonPlugin.Exceptions
{
    /// <summary>
    /// Base RegonPlugin Exception
    /// </summary>
    /// <param name="message"></param>
    public abstract class RegonException(string message) : Exception(message);

    public class RegonKeyException(string message) : RegonException(message);
    public class RegonDeserializationException(string message) : RegonException(message);
    public class RegonInvalidInputDataException(string message) : RegonException(message);
}
