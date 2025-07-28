using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadonPlugin.Converters
{
    public class StringIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException();
            }
            return int.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
