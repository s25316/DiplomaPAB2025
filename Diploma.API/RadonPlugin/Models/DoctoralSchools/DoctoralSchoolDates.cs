// Ignore Spelling: Plugin
using DoctoralSchoolResponse = RadonPlugin.Responses.NonDictionaries.DoctoralSchools.DoctoralSchool;
namespace RadonPlugin.Models.DoctoralSchools
{
    public record DoctoralSchoolDates
    {
        public DateOnly CreationDate { get; init; }
        public DateOnly? EducationStopDate { get; init; }


        public static implicit operator DoctoralSchoolDates(DoctoralSchoolResponse response)
        {
            return new DoctoralSchoolDates
            {
                CreationDate = response.CreationDate,
                EducationStopDate = response.EducationStopDate,
            };
        }
    }
}
