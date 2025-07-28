// Ignore Spelling: Plugin
using RadonPlugin.Converters;
using RadonPlugin.Responses;
using RadonPlugin.Responses.Dictionaries;
using RadonPlugin.Responses.Shared.InstitutionInfos;
using RadonPlugin.Responses.Shared.InstitutionSnapshots;
using RadonPlugin.Responses.Shared.NameStamps;
using System.Text.Json;


namespace RadonPlugin
{
    public partial class RadonClient : HttpClient
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
        private async Task<IEnumerable<DictionaryIntData>> GetDictionariesAsync(
            string urlSegment,
            CancellationToken cancellationToken = default)
        {
            return await GetDictionariesAsync<DictionaryIntData>(urlSegment, cancellationToken);
        }


        private async Task<IEnumerable<T>> GetDictionariesAsync<T>(
            string urlSegment,
            CancellationToken cancellationToken = default)
            where T : class
        {
            var endpoint = $"{ConfigurationData.BASE_URL}{ConfigurationData.URL_SEGMENT_DICTIONARIES}{urlSegment}";
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(endpoint),
            };

            var response = await SendAsync(request, cancellationToken);
            var body = await response.Content.ReadAsStringAsync();

            request.Dispose();
            response.Dispose();

            return JsonSerializer.Deserialize<ICollection<T>>(body)
                ?? throw new JsonException($"Type: {nameof(T)}, Body: {body};");
        }


        private async Task<Root<T>> GetAsync<T>(
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
