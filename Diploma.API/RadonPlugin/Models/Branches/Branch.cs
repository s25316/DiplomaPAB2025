// Ignore Spelling: Plugin, Uuid, Regon, Krs
using RadonPlugin.Models.Shared;
using RadonPlugin.Providers;
using RadonPlugin.Responses.Shared;
using RadonPlugin.Responses.Shared.NameStamps;
using BranchResponse = RadonPlugin.Responses.NonDictionaries.Branches.Branch;

namespace RadonPlugin.Models.Branches
{
    public record Branch
    {
        public Guid Uuid { get; init; }
        public string Name { get; init; } = null!;
        public Pair<Guid> MainInstitution { get; init; } = null!;
        public BranchDates Dates { get; init; } = null!;
        public string? Regon { get; init; } = null;
        public string? Nip { get; init; } = null;
        public string? Krs { get; init; } = null;
        public string? EspAddress { get; init; }
        public ContactInfo? Contacts { get; init; }
        public IReadOnlyList<NameStamp> Names { get; init; } = [];
        public IReadOnlyList<NameStamp> Statuses { get; init; } = [];
        public IReadOnlyList<AddressStamp> Addresses { get; init; } = [];
        public string DataSource { get; init; } = null!;
        public DateTime LastRefresh { get; init; }


        public static implicit operator Branch(BranchResponse response)
        {
            return new Branch
            {
                Uuid = response.Uuid,
                Name = response.Name,
                MainInstitution = new Pair<Guid>
                {
                    Id = response.MainInstitutionUuid,
                    Name = response.MainInstitutionName,
                },
                Dates = response,
                Regon = response.Regon,
                Nip = response.Nip,
                Krs = response.Krs,
                Contacts = response,
                Names = response.Names,
                Statuses = response.Statuses,
                Addresses = response.Addresses,
                DataSource = response.DataSource,
                LastRefresh = CustomTimeProvider.ParseFromUnixEpoch(response.LastRefresh),
            };
        }
    }
}
