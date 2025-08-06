// Ignore Spelling: Plugin
using BranchResponse = RadonPlugin.Responses.NonDictionaries.Branches.Branch;
namespace RadonPlugin.Models.Branches
{
    public record BranchDates
    {
        public DateOnly CreationDate { get; init; }
        public DateOnly? LiquidationStartDate { get; init; }
        public DateOnly? LiquidationDate { get; init; }


        public static implicit operator BranchDates(BranchResponse response)
        {
            return new BranchDates
            {
                CreationDate = response.CreationDate,
                LiquidationDate = response.LiquidationDate,
                LiquidationStartDate = response.LiquidationStartDate,
            };
        }
    }
}
