// Ignore Spelling: Plugin, Uuid
namespace RadonPlugin.Responses.Shared.InstitutionInfos
{
    public record InstitutionInfo
    {
        public Guid Uuid { get; init; }
        public string Name { get; init; } = null!;


        public class Builder()
        {
            private Guid _id;

            private string _name = null!;


            public Builder SetId(string? value)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _id = Guid.Parse(value);
                }
                return this;
            }

            public Builder SetName(string? value)
            {
                _name = value ?? String.Empty;
                return this;
            }

            public InstitutionInfo Build()
            {
                return new InstitutionInfo
                {
                    Uuid = _id,
                    Name = _name,
                };
            }
        }
    }
}
