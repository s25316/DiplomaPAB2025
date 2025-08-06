// Ignore Spelling: Plugin
using BranchResponse = RadonPlugin.Responses.NonDictionaries.Branches.Branch;
using InstitutionResponse = RadonPlugin.Responses.NonDictionaries.Institutions.Institution;

namespace RadonPlugin.Models.Shared
{
    public record ContactInfo
    {
        public string? Www { get; init; }
        public string? Email { get; init; }
        public string? Phone { get; init; }


        public static implicit operator ContactInfo?(InstitutionResponse response)
        {
            var www = response.Www;
            var email = response.Email;
            var phone = response.Phone;

            if (string.IsNullOrWhiteSpace(www) &&
                string.IsNullOrWhiteSpace(email) &&
                string.IsNullOrWhiteSpace(phone))
            {
                return null;
            }

            return new ContactInfo
            {
                Www = www,
                Email = email,
                Phone = phone
            };
        }

        public static implicit operator ContactInfo?(BranchResponse response)
        {
            var www = response.Www;
            var email = response.Email;
            var phone = response.Phone;

            if (string.IsNullOrWhiteSpace(www) &&
                string.IsNullOrWhiteSpace(email) &&
                string.IsNullOrWhiteSpace(phone))
            {
                return null;
            }

            return new ContactInfo
            {
                Www = www,
                Email = email,
                Phone = phone
            };
        }
    }
}
