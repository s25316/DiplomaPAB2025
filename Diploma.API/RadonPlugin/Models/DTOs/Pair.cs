// Ignore Spelling: Plugin
namespace RadonPlugin.Models.DTOs
{
    public record Pair<T>
        where T : notnull
    {
        public required T Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
