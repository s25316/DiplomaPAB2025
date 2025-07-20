// Ignore Spelling: Regon, Plugin, Szukaj, Uslugi, Komunikat, Pobierz, Pelny, Raport
// Ignore Spelling: Jednostki
using RegonPlugin.Enums;
using RegonPlugin.Exceptions;
using RegonPlugin.Models;
using RegonPlugin.Responses;
using RegonPlugin.ValueObjects;
using RaportJednostkiModel = RegonPlugin.Models.RaportJednostki;
using RaportJednostkiResponses = RegonPlugin.Responses.Raporty.Jednostki.RaportJednostki;

namespace RegonPlugin
{
    public class RegonService : IDisposable
    {
        private readonly RegonClient _client;
        private bool _disposed = false;


        public RegonService(string key, bool isProduction = true)
        {
            _client = new RegonClient(new UserKey(key), isProduction);
            //_client.ZalogujAsync().Wait();
        }


        // Dispose Methods
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
                    Console.WriteLine("Wylogowano");
                }
                _disposed = true;
            }
        }

        // Other Methods
        public async Task<Response<IEnumerable<DaneSzukaj>>> DaneSzukajAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            return await RetryAsync(
                () => _client.DaneSzukajAsync(value, by, cancellationToken),
                value => value?.Any() ?? false,
                TimeSpan.Zero,
                2,
                cancellationToken);
        }

        public async Task<Response<RaportJednostkiModel>> PobierzRaportJednostkiAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            var daneSzukajResponse = await DaneSzukajAsync(value, by, cancellationToken);
            if (daneSzukajResponse.HasErrors)
            {
                return Response<RaportJednostki>.ParseErrorResponse(daneSzukajResponse);
            }

            var item = daneSzukajResponse.Value.First();
            var raport = Raport.GetRaport(item);
            Func<RaportJednostkiResponses?, bool> hasContainsValue = value => value is not null;
            var raportJednostkiResponse = await RetryAsync(
                () => _client.PobierzRaportJednostkiAsync(item.Regon, raport.Jednostki, cancellationToken),
                hasContainsValue,
                TimeSpan.Zero,
                2,
                cancellationToken);


            if (raportJednostkiResponse.Value == null)
            {
                return Response<RaportJednostki>
                    .ParseErrorResponse(raportJednostkiResponse);
            }
            else
            {
                return Response<RaportJednostki>
                    .IsCorrect((RaportJednostki)raportJednostkiResponse.Value);
            }
        }

        private async Task<Response<T>> RetryAsync<T>(
               Func<Task<T?>> operation,
               Func<T?, bool> hasContainsValue,
               TimeSpan delay,
               int retryCount,
               CancellationToken cancellationToken)
            where T : class
        {
            try
            {
                var operationResult = await operation();
                if (hasContainsValue(operationResult) &&
                    operationResult is not null)
                {
                    return Response<T>.IsCorrect(operationResult);
                }

                var reason = await _client.KomunikatKodAsync(cancellationToken);
                if (!reason.IsNull)
                {
                    return Response<T>.KomunikatKodError(reason.Value);
                }

                await _client.ZalogujAsync(cancellationToken);
                if (retryCount > 0)
                {
                    return await RetryAsync<T>(
                        operation,
                        hasContainsValue,
                        delay,
                        retryCount - 1,
                        cancellationToken);
                }

                var statusUslugi = await _client.StatusUslugiAsync(cancellationToken);
                return Response<T>.UndefinedError(statusUslugi);
            }
            catch (RegonInvalidInputDataException ex)
            {
                return Response<T>.NiepoprawneDaneWejscioweError(ex.Message);
            }
        }
    }
}
