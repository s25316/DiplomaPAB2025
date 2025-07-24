// Ignore Spelling: Radon, Plugin
// Ignore Spelling: UUID, KRS, REGON
namespace RadonPlugin
{
    internal static class ConfigurationData
    {
        public const string BASE_URL = "https://radon.nauka.gov.pl/opendata/polon/";

        //  QUERY PARAMETERS
        public const string QUERY_PARAMETER_ID = "id=";

        public const string QUERY_PARAMETER_INSTITUTION_UUID = "institutionUuid=";

        public const string QUERY_PARAMETER_INSTITUTION_OLD_ID = "institutionUid=";

        public const string QUERY_PARAMETER_LEADING_INSTITUTION_UUID = "leadingInstitutionUuid=";

        public const string QUERY_PARAMETER_BRANCH_ID = "branchUuid=";

        public const string QUERY_PARAMETER_MAIN_INSTITUTION_NAME = "mainInstitutionName=";

        public const string QUERY_PARAMETER_MAIN_INSTITUTION_UUID = "mainInstitutionUuid=";

        public const string QUERY_PARAMETER_RESULT_NUMBERS = "resultNumbers=";

        public const string QUERY_PARAMETER_TOKEN = "token=";

        public const string QUERY_PARAMETER_NAME = "name=";

        public const string QUERY_PARAMETER_NIP = "nip=";

        public const string QUERY_PARAMETER_KRS = "krs=";

        public const string QUERY_PARAMETER_REGON = "regon=";

        // URL SEGMENTS
        public const string URL_SEGMENT_INSTITUTIONS = "institutions?";

        public const string URL_SEGMENT_BRANCHES = "branches?";

        public const string URL_SEGMENT_COURSES = "courses?";

        public const string URL_SEGMENT_DOCTORAL_SCHOOLS = "doctoralSchools?";

        public const string URL_SEGMENT_SPECIALIZED_EDUCATIONS = "specializedEducations?";
        //public const string URL_SEGMENT_

        public const int MAX_ITEMS_PER_REQUEST = 100;
    }
}
