// Ignore Spelling: Plugin, Uuid
using InstitutionResponse = RadonPlugin.Responses.NonDictionaries.Institutions.Institution;

namespace RadonPlugin.Models.Institutions
{
    public record InstitutionManagerInfo
    {
        public Guid InstitutionUuid { get; init; }
        public string Function { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Surname { get; init; } = null!;
        public string? OtherNames { get; init; }
        public string? SurnamePrefix { get; init; }


        public static implicit operator InstitutionManagerInfo?(InstitutionResponse response)
        {
            var id = response.ManagerEmployeeInInstitutionUuid;
            var function = response.ManagerFunction;
            var name = response.ManagerName;
            var surname = response.ManagerSurname;
            var otherNames = response.ManagerOtherNames;
            var surnamePrefix = response.ManagerSurnamePrefix;

            if (!id.HasValue ||
                string.IsNullOrWhiteSpace(function) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(surname))
            {
                return null;
            }

            return new InstitutionManagerInfo
            {
                InstitutionUuid = id.Value,
                Function = function,
                Name = name,
                Surname = surname,
                OtherNames = otherNames,
                SurnamePrefix = surnamePrefix
            };
        }
    }
}
