// Ignore Spelling: Plugin
using ResponseInstitution = RadonPlugin.Responses.NonDictionaries.Institutions.Institution;

namespace RadonPlugin.Models.Institutions
{
    public record InstitutionDates
    {
        public DateOnly StartDate { get; init; }
        public DateOnly? LiquidationStartDate { get; init; }
        public DateOnly? LiquidationDate { get; init; }


        public static implicit operator InstitutionDates(ResponseInstitution response)
        {
            return new InstitutionDates
            {
                StartDate = response.StartDate,
                LiquidationDate = response.LiquidationDate,
                LiquidationStartDate = response.LiquidationStartDate,
            };
        }
    }
}
