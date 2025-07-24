// Ignore Spelling: Plugin, tak, nie
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Shared
{
    public class PolishBoolConverter : JsonConverter<bool?>
    {
        public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.ToLowerInvariant() switch
            {
                "tak" => true,
                "nie" => false,
                _ => throw new JsonException(value)
            };
        }

        public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
