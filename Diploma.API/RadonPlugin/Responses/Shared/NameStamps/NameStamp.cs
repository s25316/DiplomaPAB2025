// Ignore Spelling: Radon, Plugin
namespace RadonPlugin.Responses.Shared.NameStamps
{
    public record NameStamp
    {
        public string Name { get; init; } = null!;

        public DateOnly DateFrom { get; init; }
    }
}
