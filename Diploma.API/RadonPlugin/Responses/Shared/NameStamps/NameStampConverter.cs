// Ignore Spelling 
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
                throw new JsonException();
            }

            var builder = new NameStamp.Builder();
            while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                var value = reader.GetString();

                switch (propertyName)
                {
                    case "name":
                    case "statusName":
                    case "typeName":
                        builder.SetName(value);
                        break;
                    case "dateFrom":
                        builder.SetDateFrom(value);
                        break;
                    default:
                        throw new JsonException($"{propertyName} : {value}");
                }
            }

            return builder.Build();
        }

        public override void Write(Utf8JsonWriter writer, NameStamp value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
