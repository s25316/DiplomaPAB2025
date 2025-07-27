// ignore Spelling: Plugin, 
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Shared.InstitutionInfos
{
    public class InstitutionInfoConverter : JsonConverter<InstitutionInfo>
    {
        public override InstitutionInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Oczekiwano początkowego obiektu JSON.");
            }

            var builder = new InstitutionInfo.Builder(); while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString()
                    ?? throw new ArgumentException("Property: empty");
                reader.Read();
                var value = reader.GetString();

                switch (propertyName)
                {
                    case "cooperatingInstitutionUuid":
                    case "coLeadingInstitutionUuid":
                        builder.SetId(value);
                        break;
                    case "cooperatingInstitutionName":
                    case "coLeadingInstitutionName":
                        builder.SetName(value);
                        break;
                    default:
                        throw new JsonException($"{propertyName} : {value}");
                }
            }

            return builder.Build();
        }

        public override void Write(Utf8JsonWriter writer, InstitutionInfo value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
