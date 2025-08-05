// Ignore Spelling: Plugin
using RadonPlugin.Enums;
using RadonPlugin.Responses.NonDictionaries.Branches;
using RadonPlugin.Responses.NonDictionaries.Courses;
using RadonPlugin.Responses.NonDictionaries.SpecializedEducations;
using DoctoralSchoolModel = RadonPlugin.Models.DoctoralSchools.DoctoralSchool;
using DoctoralSchoolResponse = RadonPlugin.Responses.NonDictionaries.DoctoralSchools.DoctoralSchool;
using InstitutionModel = RadonPlugin.Models.Institutions.Institution;
using InstitutionResponse = RadonPlugin.Responses.NonDictionaries.Institutions.Institution;
namespace RadonPlugin
{
    public partial class RadonClient : HttpClient
    {
        public async Task<IEnumerable<Branch>> GetBranchesAsync(
            GetBranchBy by = GetBranchBy.None,
            string? value = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Branch, GetBranchBy>(
                by,
                value,
                Factory.CreateBranchUrl,
                cancellationToken);
        }


        public async Task<IEnumerable<Course>> GetCoursesAsync(
            GetCoursesBy by = GetCoursesBy.None,
            string? value = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Course, GetCoursesBy>(
                 by,
                 value,
                 Factory.CreateCourseUrl,
                 cancellationToken);
        }


        public async Task<IEnumerable<DoctoralSchoolModel>> GetDoctoralSchoolsAsync(
            GetDoctoralSchoolBy by = GetDoctoralSchoolBy.None,
            string? value = null,
            CancellationToken cancellationToken = default)
        {
            var items = await GetAsync<DoctoralSchoolResponse, GetDoctoralSchoolBy>(
                by,
                 value,
                 Factory.CreateDoctoralSchoolUrl,
                 cancellationToken);
            return items.Select(item => (DoctoralSchoolModel)item);
        }


        public async Task<IEnumerable<InstitutionModel>> GetInstitutionsAsync(
            GetInstitutionBy by = GetInstitutionBy.None,
            string? value = null,
            CancellationToken cancellationToken = default)
        {
            var items = await GetAsync<InstitutionResponse, GetInstitutionBy>(
                by,
                value,
                Factory.CreateInstitutionUrl,
                cancellationToken);

            return items.Select(item => (InstitutionModel)item);
        }


        public async Task<IEnumerable<SpecializedEducation>> GetSpecializedEducationsAsync(
            GetSpecializedEducationBy by = GetSpecializedEducationBy.None,
            string? value = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<SpecializedEducation, GetSpecializedEducationBy>(
                by,
                value,
                Factory.CreateSpecializedEducationUrl,
                cancellationToken);
        }
    }
}
