// Ignore Spelling: Regon, Plugin
// Ignore Spelling: Uslugi, Komunikat, Kod, Sesji, Uslugi, Tresc, Pobierz, Raport, Jednostki
// Ignore Spelling: Pkd, Zaloguj, Wyloguj, Szukaj
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


        // Working without Login In
        public async Task<StatusSesji> StatusSesjiAsync(CancellationToken cancellationToken = default)
        {
            return await GetValueAsync<StatusSesji>(GetValue.StatusSesji, cancellationToken);
        }

        public async Task<StatusUslugi> StatusUslugiAsync(CancellationToken cancellationToken = default)
        {
            return await GetValueAsync<StatusUslugi>(GetValue.StatusUslugi, cancellationToken);
        }

        public async Task<string> KomunikatUslugiAsync(CancellationToken cancellationToken = default)
        {
            return await GetValueAsync(GetValue.KomunikatUslugi, cancellationToken);
        }

        // Required Login In
        public async Task<KomunikatKod?> KomunikatKodAsync(CancellationToken cancellationToken = default)
        {
            return await GetValueAsync<KomunikatKod>(GetValue.KomunikatKod, cancellationToken);
        }

        public async Task<string> KomunikatTrescAsync(CancellationToken cancellationToken = default)
        {
            return await GetValueAsync(GetValue.KomunikatTresc, cancellationToken);
        }

        public async Task<IEnumerable<DaneSzukaj>> DaneSzukajAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            DaneSzukajEnvelope request = by switch
            {
                GetBy.KRS => new DaneSzukajEnvelope((Krs)value, EndPoint),
                GetBy.NIP => new DaneSzukajEnvelope((Nip)value, EndPoint),
                GetBy.REGON => new DaneSzukajEnvelope((Regon)value, EndPoint),
                _ => throw new NotImplementedException($"{nameof(GetBy)}: {(int)by}")
            };

            var response = await SendAsync(request, cancellationToken);
            var rootElement = response.GetRoot();

            if (string.IsNullOrWhiteSpace(rootElement?.Value))
            {
                return [];
            }

            return rootElement
                .DeserializeToClass<Root<DaneSzukaj>>()?
                .Dane ?? throw new NotImplementedException($"{value} - {by}");
        }

        public async Task<RaportJednostki?> PobierzRaportJednostkiAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var reports = await PobierzRaportAsync<RaportJednostki>(regon, reportName, cancellationToken);
            return reports.FirstOrDefault();
        }

        public async Task<IEnumerable<Pkd>> PobierzPkdJednostkiAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            return await PobierzRaportAsync<Pkd>(regon, reportName, cancellationToken);
        }

        public async Task ZalogujAsync(CancellationToken cancellationToken = default)
        {
            var zalogujEnvelope = new ZalogujEnvelope(_userKey, EndPoint);
            var zalogujResponse = await SendAsync(zalogujEnvelope, cancellationToken);

            var sessionId = zalogujResponse.GetZalogujResult().Value;
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new RegonKeyException(Messages.Invalid_UserKey);
            }

            if (DefaultRequestHeaders.Contains(ConfigureData.HEADER_NAME_SESSION_ID))
            {
                DefaultRequestHeaders.Remove(ConfigureData.HEADER_NAME_SESSION_ID);
            }
            DefaultRequestHeaders.Add(ConfigureData.HEADER_NAME_SESSION_ID, sessionId);
        }

        public async Task<bool?> WylogujAsync(CancellationToken cancellationToken = default)
        {
            var sessionId = DefaultRequestHeaders.GetValues(ConfigureData.HEADER_NAME_SESSION_ID).First();

            var wylogujRequest = new WylogujEnvelope(sessionId, EndPoint);
            var wylogujResponse = await SendAsync(wylogujRequest, cancellationToken);
            var wylogujResult = wylogujResponse.GetWylogujResult()?.Value;

            return !string.IsNullOrWhiteSpace(wylogujResult)
                ? bool.Parse(wylogujResult)
                : null;
        }

        // Private Static Methods
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

        // Private NonStatic Methods
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

        private async Task<TEnum?> GetValueAsync<TEnum>(
            GetValue type,
            CancellationToken cancellationToken = default)
            where TEnum : Enum
        {
            var request = new GetValueEnvelope(type, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response
                .GetValueResult()
                .DeserializeToEnum<TEnum>();
        }

        private async Task<string> GetValueAsync(
            GetValue type,
            CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(type, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response
                .GetValueResult()
                .Value;
        }

        private async Task<IEnumerable<TResponse>> PobierzRaportAsync<TResponse>(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
            where TResponse : class
        {
            var request = new PobierzPelnyRaportEnvelope(regon, reportName, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            var rootElement = response.GetRoot();

            if (string.IsNullOrWhiteSpace(rootElement?.Value))
            {
                return [];
            }

            return rootElement
                .DeserializeToClass<Root<TResponse>>()?
                .Dane ?? throw new NotImplementedException($"{regon} - {reportName}");
        }
    }
}
