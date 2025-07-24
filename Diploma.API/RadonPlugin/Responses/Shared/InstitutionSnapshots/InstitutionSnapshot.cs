// Ignore Spelling: Plugin, Regon, Krs, Eun

using System.Globalization;

namespace RadonPlugin.Responses.Shared.InstitutionSnapshots
{
    public class InstitutionSnapshot
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = null!;

        public string? Regon { get; init; } = null;

        public string? Nip { get; init; } = null;

        public string? Krs { get; init; } = null;

        public string EunNumber { get; init; } = null!;

        public string PanNumber { get; init; } = null!;

        public string SupervisingInstitutionId { get; init; } = null!;

        public string SupervisingInstitutionName { get; init; } = null!;

        public string TransformationKind { get; init; } = null!;

        public DateOnly TransformationDate { get; init; }


        public class Builder()
        {
            private Guid _id;
            private string _name = null!;
            private string? _regon = null!;
            private string? _nip = null!;
            private string? _krs = null!;
            private string _eunNumber = null!;
            private string _panNumber = null!;
            private string _supervisingInstitutionId = null!;
            private string _supervisingInstitutionName = null!;
            private string _transformationKind = null!;
            private DateOnly _transformationDate;

            public Builder SetId(string? id)
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException(nameof(Id));
                }
                _id = Guid.Parse(id);
                return this;
            }

            public Builder SetName(string? name)
            {
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(Name));
                _name = name;
                return this;
            }

            public Builder SetRegon(string? regon)
            {
                _regon = regon;
                return this;
            }

            public Builder SetNip(string? nip)
            {
                _nip = nip;
                return this;
            }

            public Builder SetKrs(string? krs)
            {
                _krs = krs;
                return this;
            }

            public Builder SetEunNumber(string? eunNumber)
            {
                _eunNumber = eunNumber;
                return this;
            }

            public Builder SetPanNumber(string? panNumber)
            {
                _panNumber = panNumber;
                return this;
            }

            public Builder SetSupervisingInstitutionId(string? supervisingInstitutionID)
            {
                _supervisingInstitutionId = supervisingInstitutionID;
                return this;
            }

            public Builder SetSupervisingInstitutionName(string? supervisingInstitutionName)
            {
                _supervisingInstitutionName = supervisingInstitutionName;
                return this;
            }

            public Builder SetTransformationKind(string? transformationKind)
            {
                _transformationKind = transformationKind;
                return this;
            }

            public Builder SetTransformationDate(string? transformationDate)
            {
                if (string.IsNullOrEmpty(transformationDate)) throw new ArgumentException(nameof(TransformationDate));
                _transformationDate = DateOnly.Parse(transformationDate, CultureInfo.InvariantCulture);
                return this;
            }

            public InstitutionSnapshot Build()
            {
                return new InstitutionSnapshot
                {
                    Id = _id,
                    Name = _name,
                    Regon = _regon,
                    Nip = _nip,
                    Krs = _krs,
                    EunNumber = _eunNumber,
                    PanNumber = _panNumber,
                    SupervisingInstitutionId = _supervisingInstitutionId,
                    SupervisingInstitutionName = _supervisingInstitutionName,
                    TransformationKind = _transformationKind,
                    TransformationDate = _transformationDate,
                };
            }
        }
    }
}
