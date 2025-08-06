// Ignore Spelling: Plugin
using DoctoralSchoolResponse = RadonPlugin.Responses.NonDictionaries.DoctoralSchools.DoctoralSchool;
namespace RadonPlugin.Models.DoctoralSchools
{
    public record DoctoralSchoolContactInfo
    {
        public string? Www { get; init; }
        public string? Email { get; init; }


        public static implicit operator DoctoralSchoolContactInfo?(DoctoralSchoolResponse response)
        {
            if (string.IsNullOrWhiteSpace(response.Www) &&
                string.IsNullOrWhiteSpace(response.Email))
            {
                return null;
            }

            return new DoctoralSchoolContactInfo
            {
                Www = response.Www,
                Email = response.Email
            };
        }
    }
}
