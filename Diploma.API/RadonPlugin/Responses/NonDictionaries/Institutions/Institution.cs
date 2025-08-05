// Ignore spelling: Plugin, Uuid, Voivodeship, Regon, Krs, www, Pib, Eun
using RadonPlugin.Converters;
using RadonPlugin.Responses.Shared;
using RadonPlugin.Responses.Shared.InstitutionSnapshots;
using RadonPlugin.Responses.Shared.NameStamps;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Institutions
{
    public record Institution
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? Id { get; init; }

        [JsonPropertyName("institutionUuid")]
        public Guid Uuid { get; init; }

        [JsonPropertyName("institutionUid")]
        public string OldId { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("iKindCd")]
        [JsonConverter(typeof(IntegerConverter))]
        public int IKindCd { get; init; }

        [JsonPropertyName("iKindName")]
        public string IKindName { get; init; } = null!;

        [JsonPropertyName("uTypeCd")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? UTypeCd { get; init; }

        [JsonPropertyName("uTypeName")]
        public string? UTypeName { get; init; }

        [JsonPropertyName("siTypeCd")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? SiTypeCd { get; init; }

        [JsonPropertyName("siTypeName")]
        public string? SiTypeName { get; init; }

        [JsonPropertyName("statusCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int StatusCode { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; } = null!;

        [JsonPropertyName("supervisingInstitutionID")]
        public Guid? SupervisingInstitutionID { get; init; }

        [JsonPropertyName("supervisingInstitutionName")]
        public string? SupervisingInstitutionName { get; init; }

        [JsonPropertyName("countryCd")]
        [JsonConverter(typeof(IntegerConverter))]
        public int CountryCd { get; init; }

        [JsonPropertyName("country")]
        public string Country { get; init; } = null!;

        [JsonPropertyName("voivodeshipCode")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? VoivodeshipCode { get; init; }

        [JsonPropertyName("voivodeship")]
        public string? VoivodeshipName { get; init; } = null!;

        [JsonPropertyName("city")]
        public string City { get; init; } = null!;

        [JsonPropertyName("postalCd")]
        public string PostalCd { get; init; } = null!;

        [JsonPropertyName("street")]
        public string? Street { get; init; }

        [JsonPropertyName("bNumber")]
        public string BNumber { get; init; } = null!;

        [JsonPropertyName("lNumber")]
        public string? LNumber { get; init; }

        [JsonPropertyName("regon")]
        public string? Regon { get; init; }

        [JsonPropertyName("nip")]
        public string? Nip { get; init; }

        [JsonPropertyName("krs")]
        public string? Krs { get; init; }

        [JsonPropertyName("iStartDT")]
        public DateOnly StartDate { get; init; }

        [JsonPropertyName("iLiqStartDT")]
        public DateOnly? LiquidationStartDate { get; init; }

        [JsonPropertyName("iLiqDT")]
        public DateOnly? LiquidationDate { get; init; }

        [JsonPropertyName("www")]
        public string? Www { get; init; }

        [JsonPropertyName("eMail")]
        public string? Email { get; init; }

        [JsonPropertyName("phone")]
        public string? Phone { get; init; }

        [JsonPropertyName("pib")]
        [JsonConverter(typeof(IntegerConverter))]
        public int Pib { get; init; }

        [JsonPropertyName("yearPib")]
        public int? YearPib { get; init; }

        [JsonPropertyName("managerName")]
        public string? ManagerName { get; init; }

        [JsonPropertyName("managerSurname")]
        public string? ManagerSurname { get; init; }

        [JsonPropertyName("managerOtherNames")]
        public string? ManagerOtherNames { get; init; }

        [JsonPropertyName("managerSurnamePrefix")]
        public string? ManagerSurnamePrefix { get; init; }

        [JsonPropertyName("managerEmployeeInInstitutionUuid")]
        public Guid? ManagerEmployeeInInstitutionUuid { get; init; }

        [JsonPropertyName("managerFunction")]
        public string? ManagerFunction { get; init; }

        [JsonPropertyName("espAddress")]
        public string? EspAddress { get; init; }

        [JsonPropertyName("edaAddress")]
        public string? EdaAddress { get; init; }

        [JsonPropertyName("panNumber")]
        public string? PanNumber { get; init; }

        [JsonPropertyName("ministryNumber")]
        public string? MinistryNumber { get; init; }

        [JsonPropertyName("eunNumber")]
        public string? EunNumber { get; init; }

        [JsonPropertyName("federationNumber")]
        public string? FederationNumber { get; init; }

        [JsonPropertyName("branches")]
        public IReadOnlyList<InstitutionBranch> Branches { get; init; } = [];

        [JsonPropertyName("federationComposition")]
        public IReadOnlyList<InstitutionFederation> FederationComposition { get; init; } = [];

        [JsonPropertyName("transformedInstitutions")]
        public IReadOnlyList<InstitutionSnapshot> TransformedInstitutions { get; init; } = [];

        [JsonPropertyName("targetInstitutions")]
        public IReadOnlyList<InstitutionSnapshot> TargetInstitutions { get; init; } = [];

        [JsonPropertyName("names")]
        public IReadOnlyList<NameStamp> Names { get; init; } = [];

        [JsonPropertyName("supervisingInstitutions")]
        public IReadOnlyList<SupervisingInstitution> SupervisingInstitutions { get; init; } = [];

        [JsonPropertyName("statuses")]
        public IReadOnlyList<NameStamp> Statuses { get; init; } = [];

        [JsonPropertyName("types")]
        public IReadOnlyList<NameStamp> Types { get; init; } = [];

        [JsonPropertyName("addresses")]
        public IReadOnlyList<AddressStamp> Addresses { get; init; } = [];

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; } = null!;

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; } = null!;
    }
}
