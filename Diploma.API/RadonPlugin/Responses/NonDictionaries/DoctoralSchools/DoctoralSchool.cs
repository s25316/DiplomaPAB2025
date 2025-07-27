// Ignore Spelling: Plugin
using RadonPlugin.Responses.Shared.InstitutionInfos;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.DoctoralSchools
{
    public class DoctoralSchool
    {
        [JsonPropertyName("doctoralSchoolUuid")]
        public string Uuid { get; init; }

        [JsonPropertyName("doctoralSchoolCode")]
        public int Code { get; init; }

        [JsonPropertyName("doctoralSchoolName")]
        public string Name { get; init; }

        [JsonPropertyName("creationDate")]
        public string CreationDate { get; init; }

        [JsonPropertyName("responsibleInstitutionUuid")]
        public string ResponsibleInstitutionUuid { get; init; }

        [JsonPropertyName("responsibleInstitutionName")]
        public string ResponsibleInstitutionName { get; init; }

        [JsonPropertyName("coLeadingInstitutions")]
        public IReadOnlyList<InstitutionInfo> CoLeadingInstitutions { get; init; }

        [JsonPropertyName("disciplines")]
        public IReadOnlyList<DoctoralSchoolDiscipline> Disciplines { get; init; }

        [JsonPropertyName("educationStopDate")]
        public string EducationStopDate { get; init; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; init; }

        [JsonPropertyName("statusName")]
        public string StatusName { get; init; }

        [JsonPropertyName("programs")]
        public IReadOnlyList<DoctoralSchoolProgram> Programs { get; init; }

        [JsonPropertyName("countryCd")]
        public string CountryCd { get; init; }

        [JsonPropertyName("country")]
        public string Country { get; init; }

        [JsonPropertyName("voivodeship")]
        public string Voivodeship { get; init; }

        [JsonPropertyName("voivodeshipCode")]
        public string VoivodeshipCode { get; init; }

        [JsonPropertyName("city")]
        public string City { get; init; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; init; }

        [JsonPropertyName("street")]
        public string Street { get; init; }

        [JsonPropertyName("buildingNumber")]
        public string BuildingNumber { get; init; }

        [JsonPropertyName("apartmentNumber")]
        public string ApartmentNumber { get; init; }

        [JsonPropertyName("www")]
        public string Www { get; init; }

        [JsonPropertyName("eMail")]
        public string EMail { get; init; }

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; }

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; }
    }
}
