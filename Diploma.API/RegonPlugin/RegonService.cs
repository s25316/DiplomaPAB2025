// Ignore Spelling: Regon, Plugin, Szukaj, Uslugi, Komunikat, Pobierz, Pelny, Raport
// Ignore Spelling: Jednostki, Pkd
using RegonPlugin.Enums;
using RegonPlugin.Enums.GetValues;
using RegonPlugin.Exceptions;
using RegonPlugin.Models.DTOs;
using RegonPlugin.Models.Generics;
using RegonPlugin.Responses;
using RegonPlugin.ValueObjects;
using RaportJednostkiModel = RegonPlugin.Models.DTOs.RaportJednostki;

namespace RegonPlugin
{
    public class RegonService : IDisposable
    {
        private readonly RegonClient _client;
        private bool _disposed = false;


        public RegonService(string key, bool isProduction = true)
        {
            _client = new RegonClient(new UserKey(key), isProduction);
            _client.ZalogujAsync().Wait();
        }


        // DISPOSE METHODS
        ~RegonService()
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

        // OTHER METHODS
        public async Task<Response<IEnumerable<DaneSzukaj>>> GetDaneSzukajAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            return await RetryAsync(
                () => _client.DaneSzukajAsync(value, by, cancellationToken),
                value => value,
                TimeSpan.Zero,
                2,
                cancellationToken);
        }

        public async Task<Response<RaportJednostkiModel>> GetRaportJednostkiAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            var daneSzukaj = await GetDaneSzukajAsync(value, by, cancellationToken);
            if (daneSzukaj.HasErrors)
            {
                return Response<RaportJednostki>.ParseError(daneSzukaj);
            }

            var item = daneSzukaj.Value.First();
            var raport = Raport.GetRaport(item);

            var raportJednostki = await RetryAsync(
                () => _client.PobierzRaportJednostkiAsync(item.Regon, raport.Jednostki, cancellationToken),
                item => (RaportJednostki)item,
                TimeSpan.Zero,
                2,
                cancellationToken);

            return raportJednostki;
        }

        public async Task<Response<RaportJednostkiWithPkd>> GetRaportJednostkiWithPkdAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            var daneSzukaj = await GetDaneSzukajAsync(value, by, cancellationToken);
            if (daneSzukaj.HasErrors)
            {
                return Response<RaportJednostkiWithPkd>.ParseError(daneSzukaj);
            }

            var item = daneSzukaj.Value.First();
            var raport = Raport.GetRaport(item);

            var raportJednostki = await RetryAsync(
                () => _client.PobierzRaportJednostkiAsync(item.Regon, raport.Jednostki, cancellationToken),
                item => (RaportJednostki)item,
                TimeSpan.Zero,
                2,
                cancellationToken);
            if (raportJednostki.HasErrors)
            {
                return Response<RaportJednostkiWithPkd>.ParseError(daneSzukaj);
            }

            var pkd = await RetryAsync(
                () => _client.PobierzPkdJednostkiAsync(item.Regon, raport.PKD, cancellationToken),
                items => items.Select(item => (Pkd)item),
                TimeSpan.Zero,
                2,
                cancellationToken);
            if (pkd.HasErrors)
            {
                return Response<RaportJednostkiWithPkd>.ParseError(daneSzukaj);
            }

            return Response<RaportJednostkiWithPkd>.IsCorrect(new RaportJednostkiWithPkd
            {
                RaportJednostki = raportJednostki.Value,
                Pkd = pkd.Value,
            });
        }

        private async Task<Response<K>> RetryAsync<T, K>(
               Func<Task<Optional<T>>> getItemAsync,
               Func<T, K> parse,
               TimeSpan delay,
               int retryCount = 2,
               CancellationToken cancellationToken = default)
            where T : class
            where K : class
        {
            try
            {
                var item = await getItemAsync();
                if (!item.IsNullOrEmpty)
                {
                    return Response<K>.IsCorrect(parse(item.Value));
                }

                var reason = await _client.KomunikatKodAsync(cancellationToken);
                if (!reason.IsNullOrEmpty &&
                    reason.Value is not KomunikatKod.BrakSesji)
                {
                    return Response<K>.KomunikatKodError(reason.Value);
                }

                await _client.ZalogujAsync(cancellationToken);
                if (retryCount > 0)
                {
                    return await RetryAsync<T, K>(
                        getItemAsync,
                        parse,
                        delay,
                        retryCount - 1,
                        cancellationToken);
                }

                var statusUslugi = await _client.StatusUslugiAsync(cancellationToken);
                return Response<K>.ServiceError(statusUslugi);
            }
            catch (RegonInvalidInputDataException ex)
            {
                return Response<K>.InputDataError(ex.Message);
            }
        }
    }
}
