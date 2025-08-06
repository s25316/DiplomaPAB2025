// Ignore Spelling: Radon, Plugin
using System.Globalization;

namespace RadonPlugin.Responses.Shared.NameStamps
{
    public record NameStamp
    {
        public string Name { get; init; } = null!;
        public DateOnly DateFrom { get; init; }


        public class Builder
        {
            private string _name = null!;
            private DateOnly _dateFrom;


            public Builder SetName(string? name)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    _name = name;
                }
                return this;
            }

            public Builder SetDateFrom(string? dateFrom)
            {
                if (!string.IsNullOrWhiteSpace(dateFrom))
                {
                    _dateFrom = DateOnly.Parse(dateFrom, CultureInfo.InvariantCulture);
                }
                return this;
            }

            public NameStamp Build()
            {
                return new NameStamp
                {
                    Name = _name,
                    DateFrom = _dateFrom,
                };
            }
        }
    }
}
