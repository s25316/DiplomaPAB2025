// Ignore Spelling: Plugin
using RadonPlugin.Responses.Dictionaries;

namespace RadonPlugin
{
    public partial class RadonClient : HttpClient
    {
        // BRANCH
        public async Task<IEnumerable<DictionaryData>> GetBranchStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_BRANCH_STATUSES,
                cancellationToken);
        }

        // COURSE
        public async Task<IEnumerable<DictionaryData>> GetCourseLevelsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_LEVELS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCourseProfilesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_PROFILES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCourseCurrentStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_CURRENT_STATUSES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCourseLegalBasisTypesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_LEGAL_BASIS_TYPES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCourseProfessionalTitlesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_PROFESSIONAL_TITLES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCourseInstanceStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_INSTANCE_STATUSES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCourseInstanceFormsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_INSTANCE_FORMS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCoursePhilologicalLanguagesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_PHILOLOGICAL_LANGUAGES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetCourseMainInstitutionKindsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_MAIN_INSTITUTION_KINDS,
                cancellationToken);
        }


        // DOCTORAL SCHOOL
        public async Task<IEnumerable<DictionaryData>> GetDoctoralSchoolCurrentStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_DOCTORAL_SCHOOL_CURRENT_STATUSES,
                cancellationToken);
        }


        // INSTITUTION
        public async Task<IEnumerable<DictionaryData>> GetInstitutionKindsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_KINDS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetInstitutionStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_STATUSES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetInstitutionUniversityTypesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_UNIVERSITY_TYPES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetInstitutionScientificTypesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_SCIENTIFIC_TYPES,
                cancellationToken);
        }


        // SPECIALIZED EDUCATION
        public async Task<IEnumerable<DictionaryData>> GetSpecializedEducationCertificateKindsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_SPECIALIZED_EDUCATION_CERTIFICATE_KINDS,
                cancellationToken);
        }


        // SHARED
        public async Task<IEnumerable<DictionaryData>> GetSupervisingInstitutionsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_SUPERVISING_INSTITUTIONS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetDisciplinesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_DISCIPLINES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryData>> GetDomainsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_DOMAINS,
                cancellationToken);
        }
    }
}
