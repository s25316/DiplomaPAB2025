// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Institutions
{
    public class SupervisingInstitution
    {
        [JsonPropertyName("supervisingInstitutionID")]
        public Guid Id { get; init; }

        [JsonPropertyName("supervisingInstitutionName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("dateFrom")]
        public DateOnly DateFrom { get; init; }
    }
}
