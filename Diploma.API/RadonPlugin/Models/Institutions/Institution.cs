// Ignore Spelling: Plugin, Regon, Krs, Uuid, Pib, Eun
using RadonPlugin.Models.DTOs;
using RadonPlugin.Responses.NonDictionaries.Institutions;
using RadonPlugin.Responses.Shared;
using RadonPlugin.Responses.Shared.InstitutionSnapshots;
using RadonPlugin.Responses.Shared.NameStamps;
using ResponseInstitution = RadonPlugin.Responses.NonDictionaries.Institutions.Institution;

namespace RadonPlugin.Models.Institutions
{
    public class Institution
    {
        public string Id { get; init; } = null!;
        public Guid Uuid { get; init; }
        public string OldId { get; init; } = null!;
        public string? Regon { get; init; }
        public string? Nip { get; init; }
        public string? Krs { get; init; }
        public Pair<int> Kind { get; init; } = null!;
        public Pair<int>? SiType { get; init; }
        public InstitutionContactInfo? Contacts { get; init; }
        public InstitutionManagerInfo? Manager { get; init; }
        public InstitutionDates Dates { get; init; } = null!;
        public bool IsPib { get; init; }
        public int? YearPib { get; init; }
        public string? EspAddress { get; init; }
        public string? EdaAddress { get; init; }
        public string? PanNumber { get; init; }
        public string? MinistryNumber { get; init; }
        public string? EunNumber { get; init; }
        public string? FederationNumber { get; init; }
        public IReadOnlyList<NameStamp> Names { get; init; } = [];
        public IReadOnlyList<NameStamp> Statuses { get; init; } = [];
        public IReadOnlyList<NameStamp> Types { get; init; } = [];
        public IReadOnlyList<Address> Addresses { get; init; } = [];
        public IReadOnlyList<SupervisingInstitution> SupervisingInstitutions { get; init; } = [];
        public IReadOnlyList<InstitutionBranchInfo> Branches { get; init; } = [];
        public IReadOnlyList<FederationComposition> FederationComposition { get; init; } = [];
        public IReadOnlyList<InstitutionSnapshot> TransformedInstitutions { get; init; } = [];
        public IReadOnlyList<InstitutionSnapshot> TargetInstitutions { get; init; } = [];
        public string DataSource { get; init; } = null!;
        public DateTime LastRefresh { get; init; }


        public static implicit operator Institution(ResponseInstitution response)
        {
            // Kind
            var kind = new Pair<int>
            {
                Id = response.IKindCd,
                Name = response.IKindName,
            };

            // SiType
            var siType = (Pair<int>?)null;
            if (response.SiTypeCd.HasValue &&
                !string.IsNullOrWhiteSpace(response.SiTypeName))
            {
                siType = new Pair<int>
                {
                    Id = response.SiTypeCd.Value,
                    Name = response.SiTypeName,
                };
            }

            return new Institution
            {
                Regon = response.Regon,
                Nip = response.Nip,
                Krs = response.Krs,
                Id = response.Id,
                Uuid = response.Uuid,
                OldId = response.OldId,
                Kind = kind,
                SiType = siType,
                Contacts = response,
                Manager = response,
                Dates = response,
                IsPib = response.Pib > 0,
                YearPib = response.YearPib,
                EspAddress = response.EspAddress,
                EdaAddress = response.EdaAddress,
                PanNumber = response.PanNumber,
                MinistryNumber = response.MinistryNumber,
                EunNumber = response.EunNumber,
                FederationNumber = response.FederationNumber,
                Branches = response.Branches,
                Names = response.Names,
                Statuses = response.Statuses,
                Types = response.Types,
                Addresses = response.Addresses,
                FederationComposition = response.FederationComposition,
                TransformedInstitutions = response.TransformedInstitutions,
                TargetInstitutions = response.TargetInstitutions,
                SupervisingInstitutions = response.SupervisingInstitutions,
                DataSource = response.DataSource,
                LastRefresh = DateTime.UnixEpoch.AddMilliseconds(long.Parse(response.LastRefresh))
            };
        }
    }
}
