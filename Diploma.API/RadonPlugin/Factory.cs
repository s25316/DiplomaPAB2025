// Ignore Spelling: Plugin
using RadonPlugin.Enums;
using System.Text;

namespace RadonPlugin
{
    internal static class Factory
    {
        private const char QUERY_AND = '&';


        // https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_branch
        public static string CreateBranchUrl(
            GetBranchBy by,
            string value,
            string? token = null)
        {
            var queryParameter = by switch
            {
                GetBranchBy.BranchUuid => ConfigurationData.QUERY_PARAMETER_BRANCH_ID,
                GetBranchBy.Name => ConfigurationData.QUERY_PARAMETER_NAME,
                GetBranchBy.MainInstitutionUuid => ConfigurationData.QUERY_PARAMETER_MAIN_INSTITUTION_UUID,
                GetBranchBy.MainInstitutionName => ConfigurationData.QUERY_PARAMETER_MAIN_INSTITUTION_NAME,
                GetBranchBy.Regon => ConfigurationData.QUERY_PARAMETER_REGON,
                GetBranchBy.Nip => ConfigurationData.QUERY_PARAMETER_NIP,
                GetBranchBy.Krs => ConfigurationData.QUERY_PARAMETER_KRS,
                _ => throw new NotImplementedException()
            };

            return Create(
                ConfigurationData.URL_SEGMENT_BRANCHES,
                queryParameter,
                value,
                token);
        }

        // https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_course
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


        // https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_doctoral_school
        public static string CreateDoctoralSchoolUrl(
            GetDoctoralSchoolBy by,
            string value,
            string? token = null)
        {
            var queryParameter = by switch
            {
                GetDoctoralSchoolBy.DoctoralSchoolUuid => ConfigurationData.QUERY_PARAMETER_DOCTORAL_SCHOOL_UUID,
                GetDoctoralSchoolBy.DoctoralSchoolCode => ConfigurationData.QUERY_PARAMETER_DOCTORAL_SCHOOL_CODE,
                GetDoctoralSchoolBy.DoctoralSchoolName => ConfigurationData.QUERY_PARAMETER_DOCTORAL_SCHOOL_NAME,

                GetDoctoralSchoolBy.ResponsibleInstitutionUuid => ConfigurationData.QUERY_PARAMETER_RESPONSIBLE_INSTITUTION_UUID,
                GetDoctoralSchoolBy.ResponsibleInstitutionName => ConfigurationData.QUERY_PARAMETER_RESPONSIBLE_INSTITUTION_NAME,

                GetDoctoralSchoolBy.CoLeadingInstitutionUuid => ConfigurationData.QUERY_PARAMETER_CO_LEADING_INSTITUTION_UUID,
                GetDoctoralSchoolBy.CoLeadingInstitutionName => ConfigurationData.QUERY_PARAMETER_CO_LEADING_INSTITUTION_NAME,

                GetDoctoralSchoolBy.CooperatingInstitutionUuid => ConfigurationData.QUERY_PARAMETER_COOPERATING_INSTITUTION_UUID,
                GetDoctoralSchoolBy.CooperatingInstitutionName => ConfigurationData.QUERY_PARAMETER_COOPERATING_INSTITUTION_NAME,
                _ => throw new NotImplementedException()
            };

            return Create(
                ConfigurationData.URL_SEGMENT_DOCTORAL_SCHOOLS,
                queryParameter,
                value,
                token);
        }


        // https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_institution
        public static string CreateInstitutionUrl(
            GetInstitutionBy by,
            string value,
            string? token = null)
        {
            var queryParameter = by switch
            {
                GetInstitutionBy.Id => ConfigurationData.QUERY_PARAMETER_ID,
                GetInstitutionBy.Uuid => ConfigurationData.QUERY_PARAMETER_INSTITUTION_UUID,
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


        // https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_specialized_education
        public static string CreateSpecializedEducationUrl(
            GetSpecializedEducationBy by,
            string value,
            string? token = null)
        {
            var queryParameter = by switch
            {
                GetSpecializedEducationBy.SpecializedEducationUuid => ConfigurationData.QUERY_PARAMETER_SPECIALIZED_EDUCATION_UUID,
                GetSpecializedEducationBy.InstitutionUuid => ConfigurationData.QUERY_PARAMETER_INSTITUTION_UUID,
                _ => throw new NotImplementedException()
            };

            return Create(
                ConfigurationData.URL_SEGMENT_SPECIALIZED_EDUCATIONS,
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
