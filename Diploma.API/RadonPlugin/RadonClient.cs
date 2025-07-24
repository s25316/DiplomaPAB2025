// Ignore Spelling: Plugin

using RadonPlugin.Enums;
using RadonPlugin.Responses;
using RadonPlugin.Responses.Courses;
using RadonPlugin.Responses.Institutions;
using RadonPlugin.Responses.Shared.InstitutionSnapshots;
using RadonPlugin.Responses.Shared.NameStamps;
using System.Text.Json;

namespace RadonPlugin
{
    public class RadonClient : HttpClient
    {
        public async Task<IEnumerable<Institution>> GetInstitutionsAsync(
            GetInstitutionBy by,
            string value,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Factory.CreateInstitutionUrl(by, value);
            var root = await SendAsync<Institution>(endpoint, cancellationToken);
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

            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new NameStampConverter(),
                    new InstitutionSnapshotConverter(),
                }
            };
            return JsonSerializer.Deserialize<Root<T>>(body, options)
                ?? throw new JsonException($"Type: {nameof(T)}, Body: {body};");
        }
    }
}
