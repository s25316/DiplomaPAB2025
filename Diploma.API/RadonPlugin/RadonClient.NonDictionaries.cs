// Ignore Spelling: Plugin
using RadonPlugin.Enums;
using RadonPlugin.Responses.NonDictionaries.Branches;
using RadonPlugin.Responses.NonDictionaries.Courses;
using RadonPlugin.Responses.NonDictionaries.DoctoralSchools;
using RadonPlugin.Responses.NonDictionaries.Institutions;

namespace RadonPlugin
{
    public partial class RadonClient : HttpClient
    {
        public async Task<IEnumerable<Branch>> GetBranchesAsync(
            GetBranchBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateBranchUrl(by, value);
            var root = await GetAsync<Branch>(endpoint, cancellationToken);
            return root.Results;
        }


        public async Task<IEnumerable<Course>> GetCoursesAsync(
            GetCoursesBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateCourseUrl(by, value);
            var root = await GetAsync<Course>(endpoint, cancellationToken);
            return root.Results;
        }


        public async Task<IEnumerable<DoctoralSchool>> GetDoctoralSchoolsAsync(
            GetDoctoralSchoolBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateDoctoralSchoolUrl(by, value);
            var root = await GetAsync<DoctoralSchool>(endpoint, cancellationToken);
            return root.Results;
        }


        public async Task<IEnumerable<Institution>> GetInstitutionsAsync(
            GetInstitutionBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateInstitutionUrl(by, value);
            var root = await GetAsync<Institution>(endpoint, cancellationToken);
            return root.Results;
        }


        public async Task<IEnumerable<Institution>> GetSpecializedEducationsAsync(
            GetSpecializedEducationBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateSpecializedEducationUrl(by, value);
            var root = await GetAsync<Institution>(endpoint, cancellationToken);
            return root.Results;
        }
    }
}
