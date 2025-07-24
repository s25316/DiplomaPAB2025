// Ignore Spelling: Plugin
using RadonPlugin.Enums;
using System.Text;

namespace RadonPlugin
{
    internal static class Factory
    {
        private const string QUERY_AND = "&";


        public static string CreateInstitutionUrl(
            GetInstitutionBy by,
            string value,
            string? token = null)
        {
            var queryParameter = by switch
            {
                GetInstitutionBy.Id => ConfigurationData.QUERY_PARAMETER_ID,
                GetInstitutionBy.UUID => ConfigurationData.QUERY_PARAMETER_INSTITUTION_UUID,
                GetInstitutionBy.OldId => ConfigurationData.QUERY_PARAMETER_INSTITUTION_OLD_ID,
                GetInstitutionBy.Regon => ConfigurationData.QUERY_PARAMETER_REGON,
                GetInstitutionBy.Nip => ConfigurationData.QUERY_PARAMETER_NIP,
                GetInstitutionBy.Krs => ConfigurationData.QUERY_PARAMETER_KRS,
                GetInstitutionBy.Name => ConfigurationData.QUERY_PARAMETER_NAME,
                _ => throw new NotImplementedException()
            };

            return Create(
                ConfigurationData.URL_SEGMENT_INSTITUTIONS,
                queryParameter,
                value,
                token);
        }


        public static string CreateCourseUrl(
            GetCoursesBy by,
            string value,
            string? token = null)
        {
            var queryParameter = by switch
            {
                GetCoursesBy.InstitutionUuid => ConfigurationData.QUERY_PARAMETER_LEADING_INSTITUTION_UUID,
                _ => throw new NotImplementedException()
            };

            return Create(
                ConfigurationData.URL_SEGMENT_COURSES,
                queryParameter,
                value,
                token);
        }

        private static string Create(
            string urlSegment,
            string queryParameter,
            string value,
            string? token = null)
        {

            var builder = new StringBuilder();
            builder.Append(ConfigurationData.BASE_URL);
            builder.Append(urlSegment);
            builder.Append(ConfigurationData.QUERY_PARAMETER_RESULT_NUMBERS);
            builder.Append(ConfigurationData.MAX_ITEMS_PER_REQUEST);
            builder.Append(QUERY_AND);

            if (!string.IsNullOrWhiteSpace(token))
            {
                builder.Append(ConfigurationData.QUERY_PARAMETER_TOKEN);
                builder.Append(token);
                builder.Append(QUERY_AND);
            }

            builder.Append(queryParameter);
            builder.Append(value);

            return builder.ToString();
        }
    }
}
