// ignore Spelling: Plugin, Uuid
using RadonPlugin.Models.Shared;
using RadonPlugin.Providers;
using RadonPlugin.Responses.NonDictionaries.DoctoralSchools;
using RadonPlugin.Responses.Shared.InstitutionInfos;
using DoctoralSchoolResponse = RadonPlugin.Responses.NonDictionaries.DoctoralSchools.DoctoralSchool;

namespace RadonPlugin.Models.DoctoralSchools
{
    public class DoctoralSchool
    {
        public int Id { get; init; }
        public Guid Uuid { get; init; }
        public string Name { get; init; } = null!;
        public Pair<int> Status { get; init; } = null!;
        public Pair<Guid> ResponsibleInstitution { get; init; } = null!;
        public Address? Address { get; init; }
        public DoctoralSchoolContactInfo? Contacts { get; init; }
        public DoctoralSchoolDates Dates { get; init; } = null!;
        public IReadOnlyList<DoctoralSchoolDiscipline> Disciplines { get; init; } = [];
        public IReadOnlyList<DoctoralSchoolProgram> Programs { get; init; } = [];
        public IReadOnlyList<InstitutionInfo> CoLeadingInstitutions { get; init; } = [];
        public string DataSource { get; init; } = null!;
        public DateTime LastRefresh { get; init; }


        public static implicit operator DoctoralSchool(DoctoralSchoolResponse response)
        {
            return new DoctoralSchool
            {
                Uuid = response.Uuid,
                Id = response.Code,
                Name = response.Name,
                ResponsibleInstitution = new Pair<Guid>
                {
                    Id = response.ResponsibleInstitutionUuid,
                    Name = response.ResponsibleInstitutionName,
                },
                Status = new Pair<int>
                {
                    Id = response.StatusCode,
                    Name = response.StatusName,
                },
                Dates = response,
                Address = response,
                Contacts = response,
                Disciplines = response.Disciplines,
                Programs = response.Programs,
                CoLeadingInstitutions = response.CoLeadingInstitutions,
                DataSource = response.DataSource,
                LastRefresh = CustomTimeProvider.ParseFromUnixEpoch(response.LastRefresh)
            };
        }
    }
}
