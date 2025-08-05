// Ignore Spelling: Plugin
namespace RadonPlugin.Models.Shared
{
    public record Pair<T>
        where T : notnull
    {
        public required T Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
