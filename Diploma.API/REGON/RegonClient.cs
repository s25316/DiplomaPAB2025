// Ignore Spelling: Regon, Szukaj, Uslugi, Komunikat, Pobierz, Pelny, Raport
using REGON.Enums;
using REGON.Enums.GetValues;
using REGON.Providers;
using REGON.Responses;
using REGON.Responses.FullData;
using REGON.Responses.PkdData;
using REGON.ValueObjects;

namespace REGON
{
    public class RegonClient : IDisposable
    {
        // Fields
        private bool _disposed = false;
        private readonly RegonHttpClient _client;


        // Constructor
        public RegonClient(string key, bool isProduction = true)
        {
            Console.WriteLine(key);
            _client = new RegonHttpClient(new UserKey(key), isProduction);
            _client.ZalogujAsync().Wait();
        }


        //  Dispose logic
        ~RegonClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _client.WylogujAsync().Wait();
                    _client.Dispose();
                }
                _disposed = true;
            }
        }

        // Public Methods
        public async Task<StatusUslugi> StatusUslugiAsync(CancellationToken cancellationToken = default)
        {
            return await _client.StatusUslugiAsync(cancellationToken);
        }


        public async Task<IEnumerable<BaseDataResponse>> DaneSzukajAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            return await _client.DaneSzukajAsync(value, by, cancellationToken);
        }


        public async Task<FullReport> PobierzPelnyRaportAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {

            var daneSzukaj = await _client.DaneSzukajAsync(value, by, cancellationToken);

            var dane = daneSzukaj.First();
            var report = new Report(dane);

            return await _client.PobierzPelnyRaportAsync(
                dane.Regon,
                report.Main,
                cancellationToken);
        }


        public async Task<IEnumerable<Pkd>> PobierzPKDAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            var daneSzukaj = await _client.DaneSzukajAsync(value, by, cancellationToken);

            var dane = daneSzukaj.First();
            var report = new Report(dane);

            return await _client.PobierzPKDAsync(
                dane.Regon,
                report.PKD,
                cancellationToken);
        }
    }
}
