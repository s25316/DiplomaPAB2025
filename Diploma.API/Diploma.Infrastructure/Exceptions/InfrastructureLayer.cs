// Ignore Spelling: Regon
using RegonPlugin.Enums;

namespace Diploma.Infrastructure.Exceptions
{
    public abstract class InfrastructureLayer(string? message = null) : Exception(message)
    {
        public abstract class Regon(string? message = null) : InfrastructureLayer(message)
        {
            public class InvalidInputException(string message) : Regon(message);
            public class NotFoundException(string message) : Regon(message);
            public class ForbiddenException() : Regon(ErrorMessages.Regon_Forbidden_Report);
            public class ServiceNotWorkingException() : Regon(ErrorMessages.Regon_Service_Not_Working);
            public class MaintenanceBreakException() : Regon(ErrorMessages.Regon_Maintenance_Break);
            public class OtherException(string regon, RegonError? error) : Regon($"REGON: {regon}, {nameof(RegonError)} : {error}");
        }
    }
}
