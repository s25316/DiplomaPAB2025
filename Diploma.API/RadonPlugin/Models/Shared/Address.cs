// Ignore Spelling: Plugin, Voivodeship
using DoctoralSchoolResponse = RadonPlugin.Responses.NonDictionaries.DoctoralSchools.DoctoralSchool;

namespace RadonPlugin.Models.Shared
{
    public class Address
    {
        public Pair<int>? Country { get; init; } = null!;
        public Pair<int>? Voivodeship { get; init; } = null!;
        public string City { get; init; } = null!;
        public string PostalCode { get; init; } = null!;
        public string? Street { get; init; }
        public string? BuildingNumber { get; init; } = null!;
        public string? ApartmentNumber { get; init; }


        public static implicit operator Address?(DoctoralSchoolResponse response)
        {
            if (string.IsNullOrWhiteSpace(response.City) ||
                string.IsNullOrWhiteSpace(response.PostalCode) ||
                string.IsNullOrWhiteSpace(response.BuildingNumber)
                )
            {
                return null;
            }

            Pair<int>? country = null;
            Pair<int>? voivodeship = null;

            if (response.CountryCode.HasValue)
            {
                country = new Pair<int>
                {
                    Id = response.CountryCode.Value,
                    Name = response.Country ?? String.Empty,
                };
            }

            if (response.VoivodeshipCode.HasValue)
            {
                voivodeship = new Pair<int>
                {
                    Id = response.VoivodeshipCode.Value,
                    Name = response.Voivodeship ?? String.Empty,
                };
            }

            return new Address
            {
                Country = country,
                Voivodeship = voivodeship,
                City = response.City,
                PostalCode = response.PostalCode,
                Street = response.Street,
                BuildingNumber = response.BuildingNumber,
                ApartmentNumber = response.ApartmentNumber
            };
        }
    }
}
