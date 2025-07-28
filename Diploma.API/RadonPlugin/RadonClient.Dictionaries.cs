// Ignore Spelling: Plugin
using RadonPlugin.Responses.Dictionaries;

namespace RadonPlugin
{
    public partial class RadonClient : HttpClient
    {
        // BRANCH
        public async Task<IEnumerable<DictionaryIntData>> GetBranchStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_BRANCH_STATUSES,
                cancellationToken);
        }

        // COURSE
        public async Task<IEnumerable<DictionaryIntData>> GetCourseLevelsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_LEVELS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetCourseProfilesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_PROFILES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetCourseCurrentStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_CURRENT_STATUSES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetCourseLegalBasisTypesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_LEGAL_BASIS_TYPES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetCourseProfessionalTitlesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_PROFESSIONAL_TITLES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetCourseInstanceStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_INSTANCE_STATUSES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetCourseInstanceFormsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_INSTANCE_FORMS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryStringData>> GetCoursePhilologicalLanguagesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync<DictionaryStringData>(
                ConfigurationData.URL_SEGMENT_COURSE_PHILOLOGICAL_LANGUAGES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetCourseMainInstitutionKindsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_COURSE_MAIN_INSTITUTION_KINDS,
                cancellationToken);
        }


        // DOCTORAL SCHOOL
        public async Task<IEnumerable<DictionaryIntData>> GetDoctoralSchoolCurrentStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_DOCTORAL_SCHOOL_CURRENT_STATUSES,
                cancellationToken);
        }


        // INSTITUTION
        public async Task<IEnumerable<DictionaryIntData>> GetInstitutionKindsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_KINDS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetInstitutionStatusesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_STATUSES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetInstitutionUniversityTypesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_UNIVERSITY_TYPES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryIntData>> GetInstitutionScientificTypesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_INSTITUTION_SCIENTIFIC_TYPES,
                cancellationToken);
        }


        // SPECIALIZED EDUCATION
        public async Task<IEnumerable<DictionaryIntData>> GetSpecializedEducationCertificateKindsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync(
                ConfigurationData.URL_SEGMENT_SPECIALIZED_EDUCATION_CERTIFICATE_KINDS,
                cancellationToken);
        }


        // SHARED
        public async Task<IEnumerable<DictionaryGuidData>> GetSupervisingInstitutionsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync<DictionaryGuidData>(
                ConfigurationData.URL_SEGMENT_SUPERVISING_INSTITUTIONS,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryStringData>> GetDisciplinesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync<DictionaryStringData>(
                ConfigurationData.URL_SEGMENT_DISCIPLINES,
                cancellationToken);
        }


        public async Task<IEnumerable<DictionaryStringData>> GetDomainsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync<DictionaryStringData>(
                ConfigurationData.URL_SEGMENT_DOMAINS,
                cancellationToken);
        }
    }
}
