// Ignore Spelling: Plugin
using RadonPlugin.Converters;
using RadonPlugin.Enums;
using RadonPlugin.Responses;
using RadonPlugin.Responses.Branches;
using RadonPlugin.Responses.Courses;
using RadonPlugin.Responses.DoctoralSchools;
using RadonPlugin.Responses.Institutions;
using RadonPlugin.Responses.Shared.InstitutionInfos;
using RadonPlugin.Responses.Shared.InstitutionSnapshots;
using RadonPlugin.Responses.Shared.NameStamps;
using System.Text.Json;


namespace RadonPlugin
{
    public class RadonClient : HttpClient
    {
        // Fields
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters =
                {
                    new NameStampConverter(),
                    new PolishBoolConverter(),
                    new InstitutionInfoConverter(),
                    new InstitutionSnapshotConverter(),
                }
        };


        // Methods
        public async Task<IEnumerable<Branch>> GetBranchesAsync(
            GetBranchBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateBranchUrl(by, value);
            var root = await SendAsync<Branch>(endpoint, cancellationToken);
            return root.Results;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(
            GetCoursesBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateCourseUrl(by, value);
            var root = await SendAsync<Course>(endpoint, cancellationToken);
            return root.Results;
        }

        public async Task<IEnumerable<DoctoralSchool>> GetDoctoralSchoolsAsync(
            GetDoctoralSchoolBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateDoctoralSchoolUrl(by, value);
            var root = await SendAsync<DoctoralSchool>(endpoint, cancellationToken);
            return root.Results;
        }


        public async Task<IEnumerable<Institution>> GetInstitutionsAsync(
            GetInstitutionBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateInstitutionUrl(by, value);
            var root = await SendAsync<Institution>(endpoint, cancellationToken);
            return root.Results;
        }

        public async Task<IEnumerable<Institution>> GetSpecializedEducationsAsync(
            GetSpecializedEducationBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateSpecializedEducationUrl(by, value);
            var root = await SendAsync<Institution>(endpoint, cancellationToken);
            return root.Results;
        }

        private async Task<Root<T>> SendAsync<T>(
            string endpoint,
            CancellationToken cancellationToken = default)
            where T : class
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(endpoint),
            };

            var response = await SendAsync(request, cancellationToken);
            var body = await response.Content.ReadAsStringAsync();

            request.Dispose();
            response.Dispose();

            return JsonSerializer.Deserialize<Root<T>>(body, _options)
                ?? throw new JsonException($"Type: {nameof(T)}, Body: {body};");
        }
    }
}
