// Ignore Spelling: Plugin
using InstitutionResponse = RadonPlugin.Responses.NonDictionaries.Institutions.Institution;

namespace RadonPlugin.Models.Institutions
{
    public class InstitutionContactInfo
    {
        public string? Www { get; init; }
        public string? Email { get; init; }
        public string? Phone { get; init; }


        public static implicit operator InstitutionContactInfo?(InstitutionResponse response)
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

            return new InstitutionContactInfo
            {
                Www = www,
                Email = email,
                Phone = phone
            };
        }
    }
}
