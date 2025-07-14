// Ignore Spelling: Regon, Sid, Zaloguj, Wyloguj, Szukaj, Pobierz, Pelny, Raport, Pkd
// ignore Spelling: Komunikat, Uslugi, Kod, Tresc, Sesji
using REGON.Enums;
using REGON.Enums.GetValues;
using REGON.Exceptions;
using REGON.ExtensionMethods;
using REGON.Models;
using REGON.Requests;
using REGON.Requests.AuthorizationEnvelopes;
using REGON.Responses;
using REGON.Responses.FullData;
using REGON.Responses.PkdData;
using REGON.ValueObjects;
using System.Text;
using System.Xml.Linq;

namespace REGON
{
    internal class RegonClient : HttpClient
    {
        private const string PRODUCTION_ENDPOINT = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        private const string TESTING_ENDPOINT = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        private const string SESSION_ID_HEADER_NAME = "sid";
        private const int RESPONSE_MIN_LINES = 9;

        private readonly bool _isProduction;
        private readonly UserKey _userKey;

        public string EndPoint => _isProduction
            ? PRODUCTION_ENDPOINT
            : TESTING_ENDPOINT;


        // Constructor
        public RegonClient(UserKey userKey, bool isProduction = true)
        {
            _userKey = userKey;
            _isProduction = isProduction;

            BaseAddress = new Uri(EndPoint);
        }


        // Public Methods
        public async Task<StatusUslugi> StatusUslugiAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.StatusUslugi, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response
                .GetValueResult()
                .DeserializeEnum<StatusUslugi>();
        }

        public async Task<string> KomunikatUslugiAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.KomunikatUslugi, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response
                .GetValueResult()
                .Value;
        }

        public async Task<KomunikatKod> KomunikatKodAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.KomunikatKod, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response
                .GetValueResult()
                .DeserializeEnum<KomunikatKod>();
        }

        public async Task<string> KomunikatTrescAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.KomunikatTresc, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response
                .GetValueResult()
                .Value;
        }

        public async Task<StatusSesji> StatusSesjiAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.StatusSesji, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            return response
                .GetValueResult()
                .DeserializeEnum<StatusSesji>();
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

            if (DefaultRequestHeaders.Contains(SESSION_ID_HEADER_NAME))
            {
                DefaultRequestHeaders.Remove(SESSION_ID_HEADER_NAME);
            }
            DefaultRequestHeaders.Add(SESSION_ID_HEADER_NAME, sessionId);
        }

        public async Task WylogujAsync(CancellationToken cancellationToken = default)
        {
            var sessionId = DefaultRequestHeaders.GetValues(SESSION_ID_HEADER_NAME).First();

            var wylogujRequest = new WylogujEnvelope(sessionId, EndPoint);
            var wylogujResponse = await SendAsync(wylogujRequest, cancellationToken);

            var wylogujResult = wylogujResponse.GetWylogujResult();
        }


        public async Task<IEnumerable<BaseDataResponse>> DaneSzukajAsync(
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
                .DeserializeClass<Root<BaseDataResponse>>()
                .Dane;
        }

        public async Task<FullReport?> PobierzPelnyRaportAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var request = new DanePobierzPelnyRaportEnvelope(regon, reportName, EndPoint);
            var response = await SendAsync(request, cancellationToken);
            var rootElement = response.GetRoot();
            if (string.IsNullOrWhiteSpace(rootElement?.Value))
            {
                return null;
            }

            var pelnyRaport = rootElement
                .DeserializeClass<Root<FullDataResponse>>()
                .Dane
                .FirstOrDefault();
            if (pelnyRaport is null)
            {
                return null;
            }
            return (FullReport)pelnyRaport;
        }

        public async Task<IEnumerable<Pkd>> PobierzPKDAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var request = new DanePobierzPelnyRaportEnvelope(regon, reportName, EndPoint);
            var pelnyRaportResponse = await SendAsync(request, cancellationToken);
            var rootElement = pelnyRaportResponse.GetRoot();
            if (string.IsNullOrWhiteSpace(rootElement?.Value))
            {
                return [];
            }
            return rootElement
                .DeserializeClass<Root<PkdResponse>>()
                .Dane
                .Select(item => (Pkd)item);
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
                    "application/soap+xml")
            };
        }

        private static string ExtractEnvelope(string responseContent)
        {
            /* Body Response looks like for Zaloguj
            [
                  "0 ",
                  "1 --uuid:d7df59b9-21aa-45e0-97c3-54d9a4e79d76+id=42489",
                  "2 Content-ID: <http://tempuri.org/0>",
                  "3 Content-Transfer-Encoding: 8bit",
                  "4 Content-Type: application/xop+xml;charset=utf-8;type=\"application/soap+xml\"",
                  "5 ",
                  "6  => HERE ENVELOPE
                  "7 --uuid:d7df59b9-21aa-45e0-97c3-54d9a4e79d76+id=42489--",
                  "8 " 
            ]   
             */
            var lines = responseContent
                .Split("\n")
                .ToList();

            if (lines.Count < RESPONSE_MIN_LINES)
            {
                throw new NotImplementedException(); // Here 
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
                lines.Select(x => x.Trim())
                );
            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new Exception();
            }
            return ReplaceSpecifySignsToXml(responseContent);
        }

        private static string ReplaceSpecifySignsToXml(string envelope)
        {
            /* Body Response looks like for DaneSzukajByNip
             [
              "0 ",
              "1 --uuid:1afb972f-320c-4279-80f5-480b11f0dff7+id=42262",
              "2 Content-ID: <http://tempuri.org/0>",
              "3 Content-Transfer-Encoding: 8bit",
              "4 Content-Type: application/xop+xml;charset=utf-8;type=\"application/soap+xml\"",
              "5 ",
              "6 <s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajResponse</a:Action></s:Header><s:Body><DaneSzukajResponse xmlns=\"http://CIS/BIR/PUBL/2014/07\"><DaneSzukajResult>&lt;Root&gt;&#xD;",
              "7 &lt;Dane&gt;&#xD;",
              "8 &lt;Regon&gt;01081624800000&lt;/Regon&gt;&#xD;",
              "9 &lt;RegonLink&gt;&amp;lt;a href='javascript:danePobierzPelnyRaport(\"01081624800000\",\"DaneRaportPrawnaPubl\", 0);'&amp;gt;010816248&amp;lt;/a&amp;gt;&lt;/RegonLink&gt;&#xD;",
              "10 &lt;Nazwa&gt;POLSKO-JAPOŃSKA AKADEMIA TECHNIK KOMPUTEROWYCH&lt;/Nazwa&gt;&#xD;",
              "11 &lt;Wojewodztwo&gt;MAZOWIECKIE&lt;/Wojewodztwo&gt;&#xD;",
              "12 &lt;Powiat&gt;m. st. Warszawa&lt;/Powiat&gt;&#xD;",
              "13 &lt;Gmina&gt;Śródmieście&lt;/Gmina&gt;&#xD;",
              "14 &lt;Miejscowosc&gt;Warszawa&lt;/Miejscowosc&gt;&#xD;",
              "15 &lt;KodPocztowy&gt;02-008&lt;/KodPocztowy&gt;&#xD;",
              "16 &lt;Ulica&gt;ul. Test-Krucza&lt;/Ulica&gt;&#xD;",
              "17 &lt;Typ&gt;P&lt;/Typ&gt;&#xD;",
              "18 &lt;SilosID&gt;6&lt;/SilosID&gt;&#xD;",
              "19 &lt;/Dane&gt;&#xD;",
              "20 &lt;/Root&gt;</DaneSzukajResult></DaneSzukajResponse></s:Body></s:Envelope>",
              "21 --uuid:1afb972f-320c-4279-80f5-480b11f0dff7+id=42262--",
              "22 "
            ]*/
            return envelope
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&#xD;", "")
                .Replace("&amp;", "&");
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
    }
}
