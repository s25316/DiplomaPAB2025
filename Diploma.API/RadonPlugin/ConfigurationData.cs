// Ignore Spelling: Radon, Plugin
// Ignore Spelling: UUID, KRS, REGON
namespace RadonPlugin
{
    internal static class ConfigurationData
    {
        public const string BASE_URL = "https://radon.nauka.gov.pl/opendata/polon/";

        public const int MAX_ITEMS_PER_REQUEST = 100;

        // URL SEGMENTS
        public const string URL_SEGMENT_BRANCHES = "branches?";

        public const string URL_SEGMENT_COURSES = "courses?";

        public const string URL_SEGMENT_DOCTORAL_SCHOOLS = "doctoralSchools?";

        public const string URL_SEGMENT_INSTITUTIONS = "institutions?";

        public const string URL_SEGMENT_SPECIALIZED_EDUCATIONS = "specializedEducations?";

        //  QUERY PARAMETERS
        public const string QUERY_PARAMETER_TOKEN = "token=";

        public const string QUERY_PARAMETER_RESULT_NUMBERS = "resultNumbers=";


        public const string QUERY_PARAMETER_NIP = "nip=";

        public const string QUERY_PARAMETER_KRS = "krs=";

        public const string QUERY_PARAMETER_REGON = "regon=";

        public const string QUERY_PARAMETER_NAME = "name=";

        // BRANCHES
        public const string QUERY_PARAMETER_BRANCH_ID = "branchUuid=";

        public const string QUERY_PARAMETER_MAIN_INSTITUTION_UUID = "mainInstitutionUuid=";

        public const string QUERY_PARAMETER_MAIN_INSTITUTION_NAME = "mainInstitutionName=";

        // CORSES
        public const string QUERY_PARAMETER_COURSE_UUID = "courseUuid=";

        public const string QUERY_PARAMETER_COURSE_INSTANCE_UUID = "courseInstanceUuid=";

        public const string QUERY_PARAMETER_COURSE_CODE = "courseCode=";

        public const string QUERY_PARAMETER_COURSE_INSTANCE_CODE = "courseInstanceCode=";

        public const string QUERY_PARAMETER_COURSE_NAME = "courseName=";

        public const string QUERY_PARAMETER_LEADING_INSTITUTION_UUID = "leadingInstitutionUuid=";

        public const string QUERY_PARAMETER_LEADING_INSTITUTION_NAME = "leadingInstitutionName=";

        public const string QUERY_PARAMETER_CO_LEADING_INSTITUTION_UUID = "coLeadingInstitutionUuid=";

        public const string QUERY_PARAMETER_CO_LEADING_INSTITUTION_NAME = "coLeadingInstitutionName=";

        // DOCTORAL SCHOOLS
        public const string QUERY_PARAMETER_DOCTORAL_SCHOOL_UUID = "doctoralSchoolUuid=";

        public const string QUERY_PARAMETER_DOCTORAL_SCHOOL_CODE = "doctoralSchoolCode=";

        public const string QUERY_PARAMETER_DOCTORAL_SCHOOL_NAME = "doctoralSchoolName=";

        public const string QUERY_PARAMETER_RESPONSIBLE_INSTITUTION_UUID = "responsibleInstitutionUuid=";

        public const string QUERY_PARAMETER_RESPONSIBLE_INSTITUTION_NAME = "responsibleInstitutionName=";

        public const string QUERY_PARAMETER_COOPERATING_INSTITUTION_UUID = "cooperatingInstitutionUuid=";

        public const string QUERY_PARAMETER_COOPERATING_INSTITUTION_NAME = "cooperatingInstitutionName=";

        // INSTITUTIONS
        public const string QUERY_PARAMETER_ID = "id=";

        public const string QUERY_PARAMETER_INSTITUTION_UUID = "institutionUuid=";

        public const string QUERY_PARAMETER_INSTITUTION_OLD_ID = "institutionUid=";

        // SPECIALIZED EDUCATION
        public const string QUERY_PARAMETER_SPECIALIZED_EDUCATION_UUID = "specializedEducationUuid=";
    }
}
