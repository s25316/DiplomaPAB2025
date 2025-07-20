// Ignore Spelling: Regon, Plugin
// Ignore Spelling: Uslugi, Komunikat, Kod, Sesji, Uslugi, Tresc, Pobierz, Raport, Jednostki
// Ignore Spelling: Pkd, Zaloguj, Wyloguj, Szukaj, Krs
using RegonPlugin.Enums;
using RegonPlugin.Enums.GetValues;
using RegonPlugin.Exceptions;
using RegonPlugin.ExtensionMethods;
using RegonPlugin.Providers;
using RegonPlugin.Requests;
using RegonPlugin.Requests.AuthorizationEnvelopes;
using RegonPlugin.Responses;
using RegonPlugin.Responses.Raporty.Jednostki;
using RegonPlugin.Responses.Raporty.PKD;
using RegonPlugin.ValueObjects;
using System.Text;
using System.Xml.Linq;

namespace RegonPlugin
{
    internal class RegonClient : HttpClient
    {
        private const int RESPONSE_MIN_LINES = 9;

        private readonly UserKey _userKey;
        private readonly bool _isProduction;

        public string EndPoint => _isProduction
            ? ConfigureData.PRODUCTION_ENDPOINT
            : ConfigureData.TESTING_ENDPOINT;


        public RegonClient(UserKey userKey, bool isProduction = true)
        {
            _userKey = userKey;
            _isProduction = isProduction;

            BaseAddress = new Uri(EndPoint);
        }


        // LOGGIN IN/OUT OPERATIONS
        public async Task ZalogujAsync(CancellationToken cancellationToken = default)
        {
            // Need synchronization: lock or semaphore
            var sessionIdElement = await GetZalogujResultAsync(cancellationToken);
            var sessionId = sessionIdElement.Value;

            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new RegonKeyException(Messages.Invalid_UserKey);
            }

            SetSessionIdHeader(sessionId);
        }

        public async Task<bool?> WylogujAsync(CancellationToken cancellationToken = default)
        {
            var sessionId = DefaultRequestHeaders.GetValues(ConfigureData.HEADER_NAME_SESSION_ID).First();

            var wylogujResultElement = await GetWylogujResultAsync(sessionId, cancellationToken);
            var wylogujResult = wylogujResultElement.Value;

            return !string.IsNullOrWhiteSpace(wylogujResult)
                ? bool.Parse(wylogujResult)
                : null;
        }


        // CHECKING OPERATIONS WITHOUT LOGGIN IN
        public async Task<StatusSesji> StatusSesjiAsync(CancellationToken cancellationToken = default)
        {
            var getValueElement = await GetValueResultAsync(GetValue.StatusSesji, cancellationToken);
            return getValueElement.DeserializeToEnum<StatusSesji>().Value;
        }

        public async Task<StatusUslugi> StatusUslugiAsync(CancellationToken cancellationToken = default)
        {
            var getValueElement = await GetValueResultAsync(GetValue.StatusUslugi, cancellationToken);
            return getValueElement.DeserializeToEnum<StatusUslugi>().Value;
        }

        public async Task<string> KomunikatUslugiAsync(CancellationToken cancellationToken = default)
        {
            var getValueElement = await GetValueResultAsync(GetValue.KomunikatUslugi, cancellationToken);
            return getValueElement.Value;
        }

        // CHECKING OPERATIONS WITH LOGGIN IN
        public async Task<Optional<KomunikatKod>> KomunikatKodAsync(CancellationToken cancellationToken = default)
        {
            var getValueElement = await GetValueResultAsync(GetValue.KomunikatKod, cancellationToken);
            return getValueElement.DeserializeToEnum<KomunikatKod>();
        }

        public async Task<string> KomunikatTrescAsync(CancellationToken cancellationToken = default)
        {
            var getValueElement = await GetValueResultAsync(GetValue.KomunikatTresc, cancellationToken);
            return getValueElement.Value;
        }

        // GET DATA OPERATIONS
        public async Task<IEnumerable<DaneSzukaj>> DaneSzukajAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            var request = PrepareDaneSzukajEnvelope(value, by);
            return await GetDaneAsync<DaneSzukaj>(request, cancellationToken);
        }

        public async Task<RaportJednostki?> PobierzRaportJednostkiAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var request = new RaportEnvelope(regon, reportName, EndPoint);
            var dane = await GetDaneAsync<RaportJednostki>(request, cancellationToken);
            return dane.FirstOrDefault();
        }

        public async Task<IEnumerable<Pkd>> PobierzPkdJednostkiAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var request = new RaportEnvelope(regon, reportName, EndPoint);
            return await GetDaneAsync<Pkd>(request, cancellationToken);
        }

        // PRIVATE STATIC METHODS
        private static HttpRequestMessage PrepareRequest(string envelope)
        {
            return new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent(
                    envelope,
                    Encoding.UTF8,
                    ConfigureData.REQUEST_MEDIA_TYPE)
            };
        }

        private static string ExtractEnvelope(string responseContent)
        {
            var lines = responseContent
                .Split("\n")
                .ToList();

            if (lines.Count < RESPONSE_MIN_LINES)
            {
                throw new NotImplementedException(responseContent);
            }

            for (int i = 0; i < 6; i++)
            {
                lines.RemoveAt(0);
            }
            for (int i = 0; i < 2; i++)
            {
                lines.RemoveAt(lines.Count - 1);
            }

            responseContent = string.Join(
                "",
                lines.Select(x => x.Trim()));

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new NotImplementedException(responseContent);
            }

            return CustomStringProvider.DecodeXmlEnvelope(responseContent);
        }

        // PRIVATE NONSTATIC METHODS
        private async Task<XDocument> SendAsync(
            string envelope,
            CancellationToken cancellationToken = default)
        {
            var request = PrepareRequest(envelope);
            var response = await base.SendAsync(request, cancellationToken);
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            request.Dispose();
            response.Dispose();

            var xmlEnvelope = ExtractEnvelope(responseContent);
            return XDocument.Parse(xmlEnvelope);
        }

        private async Task<XElement> GetZalogujResultAsync(CancellationToken cancellationToken = default)
        {
            var zalogujEnvelope = new ZalogujEnvelope(_userKey, EndPoint);
            var zalogujResponse = await SendAsync(zalogujEnvelope, cancellationToken);
            return zalogujResponse.GetZalogujResult();
        }

        private async Task<XElement> GetWylogujResultAsync(
            string sessionId,
            CancellationToken cancellationToken = default)
        {
            var wylogujRequest = new WylogujEnvelope(sessionId, EndPoint);
            var wylogujResponse = await SendAsync(wylogujRequest, cancellationToken);
            return wylogujResponse.GetWylogujResult();
        }

        private async Task<XElement> GetValueResultAsync(
            GetValue type,
            CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(type, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response.GetValueResult();
        }

        private async Task<IEnumerable<T>> GetDaneAsync<T>(
            string request,
            CancellationToken cancellationToken = default)
            where T : class
        {
            var response = await SendAsync(request, cancellationToken);
            var dane = response.GetDane();

            var resultList = new List<T>();
            foreach (var item in dane)
            {
                var deserializedItem = item.DeserializeToClass<T>();
                if (deserializedItem.Value != null)
                {
                    resultList.Add(deserializedItem.Value);
                }
            }

            return resultList;
        }

        private DaneSzukajEnvelope PrepareDaneSzukajEnvelope(
            string value,
            GetBy by)
        {
            return by switch
            {
                GetBy.KRS => new DaneSzukajEnvelope((Krs)value, EndPoint),
                GetBy.NIP => new DaneSzukajEnvelope((Nip)value, EndPoint),
                GetBy.REGON => new DaneSzukajEnvelope((Regon)value, EndPoint),
                _ => throw new NotImplementedException($"{nameof(GetBy)}: {(int)by}")
            };
        }

        private void SetSessionIdHeader(string sessionId)
        {
            if (DefaultRequestHeaders.Contains(ConfigureData.HEADER_NAME_SESSION_ID))
            {
                DefaultRequestHeaders.Remove(ConfigureData.HEADER_NAME_SESSION_ID);
                Console.WriteLine($"Zaktualizowano");
            }
            else
            {
                Console.WriteLine($"Zalogowano");
            }
            DefaultRequestHeaders.Add(ConfigureData.HEADER_NAME_SESSION_ID, sessionId);
        }
    }
}
