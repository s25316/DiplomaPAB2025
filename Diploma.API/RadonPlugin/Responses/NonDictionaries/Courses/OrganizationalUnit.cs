// ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public class OrganizationalUnit
    {
        [JsonPropertyName("organizationalUnitUuid")]
        public Guid Id { get; init; }

        [JsonPropertyName("organizationalUnitFullName")]
        public string Name { get; init; } = null!;
    }
}
