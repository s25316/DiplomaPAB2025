// Ignore Spelling:  Teryt, Plugin
namespace TerytPlugin.Models
{
    public class TerytInfo
    {
        public IEnumerable<string> DivisionTypes { get; init; } = [];
        public IEnumerable<Division> Divisions { get; init; } = [];

        public IEnumerable<string> StreetTypes { get; init; } = [];
        public IEnumerable<Street> Streets { get; init; } = [];

        public IEnumerable<Connection> Connections { get; init; } = [];
    }
}
