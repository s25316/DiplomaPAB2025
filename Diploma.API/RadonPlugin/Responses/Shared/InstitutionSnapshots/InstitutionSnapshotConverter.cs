using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Shared.InstitutionSnapshots
{
    public class InstitutionSnapshotConverter : JsonConverter<InstitutionSnapshot>
    {
        public override InstitutionSnapshot? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Oczekiwano początkowego obiektu JSON.");
            }

            var builder = new InstitutionSnapshot.Builder();

            while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString()
                    ?? throw new ArgumentException("Property: empty");
                reader.Read();
                var value = reader.GetString();

                switch (propertyName)
                {
                    case "targetInstitutionUuid":
                    case "transformedInstitutionUuid":
                        builder.SetId(value);
                        break;
                    case "targetInstitutionName":
                    case "transformedInstitutionName":
                        builder.SetName(value);
                        break;
                    case "regon":
                        builder.SetRegon(value);
                        break;
                    case "nip":
                        builder.SetNip(value);
                        break;
                    case "krs":
                        builder.SetKrs(value);
                        break;
                    case "eunNumber":
                        builder.SetEunNumber(value);
                        break;
                    case "panNumber":
                        builder.SetPanNumber(value);
                        break;
                    case "supervisingInstitutionID":
                        builder.SetSupervisingInstitutionId(value);
                        break;
                    case "supervisingInstitutionName":
                        builder.SetSupervisingInstitutionName(value);
                        break;
                    case "transformationKind":
                        builder.SetTransformationKind(value);
                        break;
                    case "transformationDate":
                        builder.SetTransformationDate(value);
                        break;
                    default:
                        throw new JsonException($"{propertyName} : {value}");
                }
            }

            return builder.Build();
        }

        public override void Write(Utf8JsonWriter writer, InstitutionSnapshot value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
