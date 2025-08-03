// Ignore Spelling: Plugin
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadonPlugin.Converters
{
    public class IntegerNullConverter : JsonConverter<int?>
    {
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt32();
            }

            var value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return int.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
        {
            if (value.HasValue) writer.WriteNumberValue(value.Value);
            else writer.WriteNullValue();
        }
    }
}
