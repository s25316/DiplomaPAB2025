// Ignore Spelling: Regon, Sid, Zaloguj, Wyloguj, Szukaj, Pobierz, Pelny, Raport, Pkd
// ignore Spelling: Komunikat, Uslugi
using REGON.Enums;
using REGON.Enums.GetValues;
using REGON.Exceptions;
using REGON.ExtensionMethods;
using REGON.Requests;
using REGON.Requests.AuthorizationEnvelopes;
using REGON.Responses;
using REGON.Responses.FullData;
using REGON.Responses.PkdData;
using REGON.ValueObjects;
using System.Text;
using System.Xml.Linq;

namespace REGON.Providers
{
    internal class RegonHttpClient : HttpClient
    {
        // Fields
        public const string PRODUCTION_ENDPOINT = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        public const string TESTING_ENDPOINT = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";

        private const string SID = "sid";
        private const int RESPONSE_MIN_LINES = 9;

        public string EndPoint => _isProduction
            ? PRODUCTION_ENDPOINT
            : TESTING_ENDPOINT;

        private readonly bool _isProduction;
        private readonly UserKey _userKey;



        // Constructor
        public RegonHttpClient(UserKey userKey, bool isProduction = true)
        {
            _userKey = userKey;
            _isProduction = isProduction;

            BaseAddress = new Uri(EndPoint);
        }


        // Public Methods
        public async Task ZalogujAsync(CancellationToken cancellationToken = default)
        {
            var zalogujEnvelope = new ZalogujEnvelope(_userKey, EndPoint);
            var zalogujResponse = await SendAsync(
                zalogujEnvelope,
                cancellationToken);

            var sessionIdXMLElement = zalogujResponse.GetZalogujResult();
            if (sessionIdXMLElement?.Value == null)
            {
                throw new RegonClientException(
                    Messages.UserKey_Invalid,
                    ExceptionType.UserKey
                    );
            }

            if (DefaultRequestHeaders.Contains(SID))
            {
                DefaultRequestHeaders.Remove(SID);
            }
            DefaultRequestHeaders.Add(SID, sessionIdXMLElement.Value);
            Console.WriteLine("Zalogowano");
        }


        public async Task WylogujAsync(CancellationToken cancellationToken = default)
        {
            var sessionId = DefaultRequestHeaders.GetValues(SID).First();

            var wylogujRequest = new WylogujEnvelope(sessionId, EndPoint);
            var wylogujResponse = await SendAsync(wylogujRequest, cancellationToken);

            var wylogujResult = wylogujResponse.GetWylogujResult();
            Console.WriteLine("Wylogowano");
        }


        public async Task<StatusUslugi> StatusUslugiAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.StatusUslugi, EndPoint);
            var response = await SendAsync(request, cancellationToken);

            return response.GetValueResult()?.DeserializeEnum<StatusUslugi>()
                ?? throw new Exception("Value always be");
        }

        public async Task<string> KomunikatUslugiAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.KomunikatUslugi, EndPoint);
            var response = await SendAsync(request, cancellationToken);

            return response.GetValueResult()?.Value
                ?? throw new Exception("Value always be");
        }


        private async Task<KomunikatKod> KomunikatKodAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.KomunikatKod, EndPoint);
            var response = await SendAsync(
                request,
                cancellationToken);

            return response.GetValueResult()?.DeserializeEnum<KomunikatKod>()
                ?? throw new Exception("Value always be");
        }

        private async Task<string> KomunikatTrescAsync(CancellationToken cancellationToken = default)
        {
            var request = new GetValueEnvelope(GetValue.KomunikatTresc, EndPoint);
            var response = await SendAsync(
                request,
                cancellationToken);

            return response.GetValueResult()?.Value
                ?? throw new Exception("Value always be");
        }


        public async Task<IEnumerable<BaseDataResponse>> DaneSzukajAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            DaneSzukajEnvelope daneSzukajRequest;
            switch (by)
            {
                case GetBy.KRS:
                    daneSzukajRequest = new DaneSzukajEnvelope((Krs)value, EndPoint);
                    break;
                case GetBy.NIP:
                    daneSzukajRequest = new DaneSzukajEnvelope((Nip)value, EndPoint);
                    break;
                case GetBy.REGON:
                    daneSzukajRequest = new DaneSzukajEnvelope((Regon)value, EndPoint);
                    break;
                default:
                    throw new NotImplementedException($"{nameof(GetBy)}: {(int)by}");
            }
            var daneSzukajResponse = await SendAsync(
                daneSzukajRequest,
                cancellationToken);

            var rootElement = daneSzukajResponse.GetRoot()
                ?? throw new NotImplementedException();

            var root = rootElement.DeserializeClass<Root<BaseDataResponse>>();

            // if not found Exception check why
            if (!root.Dane.Any())
            {
                // Not Found Property Why?
                throw new Exception();
            }
            return root.Dane;
        }

        public async Task<FullReport> PobierzPelnyRaportAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var pelnyRaportEnvelope = new DanePobierzPelnyRaportEnvelope(
                regon,
                reportName,
                EndPoint);

            var pelnyRaportResponse = await SendAsync(
                pelnyRaportEnvelope,
                cancellationToken);

            var root = pelnyRaportResponse.GetRoot()
                ?? throw new Exception();
            var pelnyRaport = root.DeserializeClass<Root<FullDataResponse>>();

            return (FullReport)pelnyRaport.Dane.First();
        }

        public async Task<IEnumerable<Pkd>> PobierzPKDAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var pelnyRaportEnvelope = new DanePobierzPelnyRaportEnvelope(
                regon,
                reportName,
                EndPoint);

            var pelnyRaportResponse = await SendAsync(
                pelnyRaportEnvelope,
                cancellationToken);

            var root = pelnyRaportResponse.GetRoot()
                ?? throw new Exception();
            var pelnyRaport = root.DeserializeClass<Root<PkdResponse>>();

            Console.WriteLine(pelnyRaport.Dane.Count);

            return pelnyRaport.Dane.Select(item => (Pkd)item);
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

        public XDocument Send(
            string envelope,
            CancellationToken cancellationToken = default)
        {
            var request = PrepareRequest(envelope);
            var response = base.Send(request, cancellationToken);
            var responseContent = response.Content.ToString();

            request.Dispose();
            response.Dispose();


            var xmlEnvelope = ExtractEnvelope(responseContent);
            return XDocument.Parse(xmlEnvelope);
        }
    }
}
