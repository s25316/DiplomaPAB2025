using System.Text.Json.Serialization;

namespace REGON.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RequestResult
    {
        Success,
        InvalidInputData,
        NotFound,
        ForbiddenReport
    }
}
