// Ignore Spelling: Plugin, Uuid, Voivodeship, www
using RadonPlugin.Converters;
using RadonPlugin.Responses.Shared.InstitutionInfos;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.DoctoralSchools
{
    public class DoctoralSchool
    {
        [JsonPropertyName("doctoralSchoolUuid")]
        public Guid Uuid { get; init; }

        [JsonPropertyName("doctoralSchoolCode")]
        public int Code { get; init; }

        [JsonPropertyName("doctoralSchoolName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("creationDate")]
        public DateOnly CreationDate { get; init; }

        [JsonPropertyName("educationStopDate")]
        public DateOnly? EducationStopDate { get; init; }

        [JsonPropertyName("responsibleInstitutionUuid")]
        public Guid ResponsibleInstitutionUuid { get; init; }

        [JsonPropertyName("responsibleInstitutionName")]
        public string ResponsibleInstitutionName { get; init; } = null!;

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; init; }

        [JsonPropertyName("statusName")]
        public string StatusName { get; init; } = null!;

        [JsonPropertyName("countryCd")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? CountryCode { get; init; } = null;

        [JsonPropertyName("country")]
        public string? Country { get; init; } = null!;

        [JsonPropertyName("voivodeshipCode")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? VoivodeshipCode { get; init; }

        [JsonPropertyName("voivodeship")]
        public string? Voivodeship { get; init; }

        [JsonPropertyName("city")]
        public string? City { get; init; } = null!;

        [JsonPropertyName("postalCode")]
        public string? PostalCode { get; init; } = null!;

        [JsonPropertyName("street")]
        public string? Street { get; init; }

        [JsonPropertyName("buildingNumber")]
        public string? BuildingNumber { get; init; } = null!;

        [JsonPropertyName("apartmentNumber")]
        public string? ApartmentNumber { get; init; }

        [JsonPropertyName("www")]
        public string? Www { get; init; }

        [JsonPropertyName("eMail")]
        public string? Email { get; init; }

        [JsonPropertyName("disciplines")]
        public IReadOnlyList<DoctoralSchoolDiscipline> Disciplines { get; init; } = [];

        [JsonPropertyName("programs")]
        public IReadOnlyList<DoctoralSchoolProgram> Programs { get; init; } = [];

        [JsonPropertyName("coLeadingInstitutions")]
        public IReadOnlyList<InstitutionInfo> CoLeadingInstitutions { get; init; } = [];

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; } = null!;

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; } = null!;
    }
}
