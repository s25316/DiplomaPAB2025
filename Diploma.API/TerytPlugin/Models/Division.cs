// Ignore spelling: Teryt, Plugin
namespace TerytPlugin.Models
{
    public record Division
    {
        public string? ParentId { get; init; } = null;
        public string Id { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Type { get; init; } = null!;
    }
}
