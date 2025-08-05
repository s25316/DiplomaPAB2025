// Ignore Spelling: Plugin
using InstitutionResponse = RadonPlugin.Responses.NonDictionaries.Institutions.Institution;

namespace RadonPlugin.Models.Institutions
{
    public record InstitutionDates
    {
        public DateOnly StartDate { get; init; }
        public DateOnly? LiquidationStartDate { get; init; }
        public DateOnly? LiquidationDate { get; init; }


        public static implicit operator InstitutionDates(InstitutionResponse response)
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
