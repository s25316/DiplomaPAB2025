namespace Diploma.Domain.Shared.Exceptions
{
    public abstract class Resource(string? message) : Exception(message)
    {
        public class InvalidInputException(string? message) : Resource(message);
        public class NotFoundException(string? message) : Resource(message);
        public class ForbiddenException(string? message) : Resource(message);
    }
}
