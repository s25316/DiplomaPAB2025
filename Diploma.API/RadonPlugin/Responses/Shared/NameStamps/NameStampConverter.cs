using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Shared.NameStamps
{
    public class NameStampConverter : JsonConverter<NameStamp>
    {
        public override NameStamp? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Oczekiwano początkowego obiektu JSON.");
            }

            var name = string.Empty;
            DateOnly date = DateOnly.MinValue;

            while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString()
                    ?? throw new ArgumentException("Property: empty");
                reader.Read();
                string value = reader.GetString()
                    ?? throw new ArgumentException("Property Value: empty");

                switch (propertyName)
                {
                    case "name":
                    case "statusName":
                    case "typeName":
                        name = value;
                        break;
                    case "dateFrom":
                        date = DateOnly.Parse(value, CultureInfo.InvariantCulture);
                        break;
                    default:
                        throw new JsonException($"{propertyName} : {value}");
                }
            }

            return new NameStamp
            {
                Name = name,
                DateFrom = date,
            };
        }

        public override void Write(Utf8JsonWriter writer, NameStamp value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
