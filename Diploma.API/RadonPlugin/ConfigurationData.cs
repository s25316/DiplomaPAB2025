// Ignore Spelling: Radon, Plugin
// Ignore Spelling: UUID, KRS, REGON
namespace RadonPlugin
{
    internal static class ConfigurationData
    {
        public const string BASE_URL = "https://radon.nauka.gov.pl/opendata/polon/";

        public const int MAX_ITEMS_PER_REQUEST = 100;



        // ==============================================================================================
        // DICTIONARY DATA
        // ==============================================================================================
        public const string URL_SEGMENT_DICTIONARIES = "dictionaries/";

        // BRANCH
        public const string URL_SEGMENT_BRANCH_STATUSES = "branch/branchStatuses";

        // COURSE
        public const string URL_SEGMENT_COURSE_LEVELS = "course/levels";

        public const string URL_SEGMENT_COURSE_PROFILES = "course/profiles";

        public const string URL_SEGMENT_COURSE_CURRENT_STATUSES = "course/currentStatuses";

        public const string URL_SEGMENT_COURSE_LEGAL_BASIS_TYPES = "course/legalBasisTypes";

        public const string URL_SEGMENT_COURSE_PROFESSIONAL_TITLES = "course/professionalTitles";

        public const string URL_SEGMENT_COURSE_INSTANCE_STATUSES = "course/instanceStatuses";

        public const string URL_SEGMENT_COURSE_INSTANCE_FORMS = "course/instanceForms";

        public const string URL_SEGMENT_COURSE_PHILOLOGICAL_LANGUAGES = "course/philologicalLanguages";

        public const string URL_SEGMENT_COURSE_MAIN_INSTITUTION_KINDS = "course/mainInstitutionKinds";

        // DOCTORAL SCHOOL
        public const string URL_SEGMENT_DOCTORAL_SCHOOL_CURRENT_STATUSES = "doctoralSchool/currentStatuses";

        // INSTITUTION
        public const string URL_SEGMENT_INSTITUTION_KINDS = "institution/institutionKinds";

        public const string URL_SEGMENT_INSTITUTION_STATUSES = "institution/institutionStatuses";

        public const string URL_SEGMENT_INSTITUTION_UNIVERSITY_TYPES = "institution/universityTypes";

        public const string URL_SEGMENT_INSTITUTION_SCIENTIFIC_TYPES = "institution/scientificInstitutionTypes";

        // SPECIALIZED EDUCATION
        public const string URL_SEGMENT_SPECIALIZED_EDUCATION_CERTIFICATE_KINDS = "specialized-education/certificateKinds";

        // SHARED
        public const string URL_SEGMENT_SUPERVISING_INSTITUTIONS = "shared/supervisingInstitutions";

        public const string URL_SEGMENT_DISCIPLINES = "shared/disciplines";

        public const string URL_SEGMENT_DOMAINS = "shared/domains";

        // ==============================================================================================
        // NON DICTIONARY DATA
        // ==============================================================================================
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
