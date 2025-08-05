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
                    new IntegerConverter(),
                    new IntegerNullConverter(),
                    new DateOnlyConverter(),
                    new PolishBoolConverter(),

                    new NameStampConverter(),
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


        private async Task<Root<T>> MakeRequestNonDictionariesAsync<T>(
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

        private async Task<IEnumerable<T>> GetAsync<T, TEnum>(
            TEnum getBy,
            string? value,
            Func<TEnum, string?, string?, string> createEndPoint,
            CancellationToken cancellationToken = default)
            where T : class
            where TEnum : Enum
        {
            string? token = null;
            var maxCount = 0;
            var list = new List<T>();

            do
            {
                var baseUrl = createEndPoint(getBy, value, token);
                var root = await MakeRequestNonDictionariesAsync<T>(baseUrl, cancellationToken);

                list.AddRange(root.Results);
                token = root.Pagination.Token;
                maxCount = root.Pagination.MaxCount;
            }
            while (list.Count < maxCount);

            return list;
        }
    }
}
