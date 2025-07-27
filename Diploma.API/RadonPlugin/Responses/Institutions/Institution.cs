using RadonPlugin.Responses.Shared;
using RadonPlugin.Responses.Shared.InstitutionSnapshots;
using RadonPlugin.Responses.Shared.NameStamps;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Institutions
{
    public record Institution
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("institutionUuid")]
        public Guid Uuid { get; init; }

        [JsonPropertyName("institutionUid")]
        public string OldId { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("iKindCd")]
        public string IKindCd { get; init; }

        [JsonPropertyName("iKindName")]
        public string IKindName { get; init; }

        [JsonPropertyName("uTypeCd")]
        public string UTypeCd { get; init; }

        [JsonPropertyName("uTypeName")]
        public string UTypeName { get; init; }

        [JsonPropertyName("siTypeCd")]
        public string SiTypeCd { get; init; }

        [JsonPropertyName("siTypeName")]
        public string SiTypeName { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }

        [JsonPropertyName("supervisingInstitutionID")]
        public string SupervisingInstitutionID { get; init; }

        [JsonPropertyName("supervisingInstitutionName")]
        public string SupervisingInstitutionName { get; init; }

        [JsonPropertyName("countryCd")]
        public string CountryCd { get; init; }

        [JsonPropertyName("country")]
        public string Country { get; init; }

        [JsonPropertyName("voivodeship")]
        public string Voivodeship { get; init; }

        [JsonPropertyName("city")]
        public string City { get; init; }

        [JsonPropertyName("postalCd")]
        public string PostalCd { get; init; }

        [JsonPropertyName("street")]
        public string Street { get; init; }

        [JsonPropertyName("bNumber")]
        public string BNumber { get; init; }

        [JsonPropertyName("lNumber")]
        public string LNumber { get; init; }

        [JsonPropertyName("regon")]
        public string Regon { get; init; }

        [JsonPropertyName("nip")]
        public string Nip { get; init; }

        [JsonPropertyName("krs")]
        public string Krs { get; init; }

        [JsonPropertyName("iStartDT")]
        public DateOnly StartDate { get; init; }

        [JsonPropertyName("iLiqStartDT")]
        public DateOnly? LiquidationStartDate { get; init; }

        [JsonPropertyName("iLiqDT")]
        public DateOnly? LiquidationDate { get; init; }

        [JsonPropertyName("www")]
        public string Www { get; init; }

        [JsonPropertyName("eMail")]
        public string EMail { get; init; }

        [JsonPropertyName("phone")]
        public string Phone { get; init; }

        [JsonPropertyName("pib")]
        public string Pib { get; init; }

        [JsonPropertyName("yearPib")]
        public string YearPib { get; init; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; init; }

        [JsonPropertyName("voivodeshipCode")]
        public string VoivodeshipCode { get; init; }

        [JsonPropertyName("branches")]
        public List<InstitutionBranchInfo> Branches { get; init; }

        [JsonPropertyName("managerName")]
        public string ManagerName { get; init; }

        [JsonPropertyName("managerSurname")]
        public string ManagerSurname { get; init; }

        [JsonPropertyName("managerOtherNames")]
        public string ManagerOtherNames { get; init; }

        [JsonPropertyName("managerSurnamePrefix")]
        public string ManagerSurnamePrefix { get; init; }

        [JsonPropertyName("managerEmployeeInInstitutionUuid")]
        public string ManagerEmployeeInInstitutionUuid { get; init; }

        [JsonPropertyName("managerFunction")]
        public string ManagerFunction { get; init; }

        [JsonPropertyName("espAddress")]
        public string EspAddress { get; init; }

        [JsonPropertyName("edaAddress")]
        public string EdaAddress { get; init; }

        [JsonPropertyName("panNumber")]
        public string PanNumber { get; init; }

        [JsonPropertyName("ministryNumber")]
        public string MinistryNumber { get; init; }

        [JsonPropertyName("eunNumber")]
        public string EunNumber { get; init; }

        [JsonPropertyName("federationNumber")]
        public string FederationNumber { get; init; }

        [JsonPropertyName("federationComposition")]
        public List<FederationComposition> FederationComposition { get; init; } = [];

        [JsonPropertyName("transformedInstitutions")]
        public List<InstitutionSnapshot> TransformedInstitutions { get; init; } = [];

        [JsonPropertyName("targetInstitutions")]
        public List<InstitutionSnapshot> TargetInstitutions { get; init; } = [];

        [JsonPropertyName("names")]
        public List<NameStamp> Names { get; init; } = [];

        [JsonPropertyName("supervisingInstitutions")]
        public List<SupervisingInstitution> SupervisingInstitutions { get; init; } = [];

        [JsonPropertyName("statuses")]
        public List<NameStamp> Statuses { get; init; } = [];

        [JsonPropertyName("types")]
        public List<NameStamp> Types { get; init; } = [];

        [JsonPropertyName("addresses")]
        public List<Address> Addresses { get; init; } = [];

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; } = null!;

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; } = null!;
    }
}
