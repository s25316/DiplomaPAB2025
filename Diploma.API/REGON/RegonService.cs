// Ignore Spelling: Regon, Szukaj, Uslugi, Komunikat, Pobierz, Pelny, Raport
using REGON.Enums;
using REGON.Enums.GetValues;
using REGON.Exceptions;
using REGON.Models;
using REGON.Responses;
using REGON.ValueObjects;

namespace REGON
{
    public class RegonService : IDisposable
    {
        // Fields
        private bool _disposed = false;
        private readonly RegonClient _client;


        // Constructor
        public RegonService(string key, bool isProduction = true)
        {
            _client = new RegonClient(new UserKey(key), isProduction);
            _client.ZalogujAsync().Wait();
        }


        //  Dispose logic
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

        // Public Methods


        public async Task<BaseCompanyData> GetAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var (responseBD, dane) = await DaneSzukajAsync(value, by, cancellationToken);
                if (dane is null)
                {
                    return responseBD;
                }

                var report = new Report(dane);
                var (responsePR, fullReport) = await PobierzPelnyRaportAsync(
                    dane.Regon,
                    report.Main,
                    cancellationToken);
                if (fullReport is null)
                {
                    return responsePR;
                }

                var (responsePKD, pkd) = await PobierzPKDAsync(
                    dane.Regon,
                    report.PKD,
                    cancellationToken);
                if (!pkd.Any())
                {
                    return responsePKD;
                }

                return new BaseCompanyData
                {
                    Status = RequestResult.Success,
                    Report = fullReport,
                    Pkd = pkd,
                };
            }
            catch (InvalidInputDataException ex)
            {
                return new BaseCompanyData
                {
                    Status = RequestResult.InvalidInputData,
                    Message = ex.Message,
                };
            }
        }

        private async Task<(BaseCompanyData Response, BaseDataResponse? BaseData)> DaneSzukajAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken = default)
        {
            var daneSzukaj = await _client.DaneSzukajAsync(value, by, cancellationToken);

            var dane = daneSzukaj.FirstOrDefault();

            BaseCompanyData response;
            if (dane is not null)
            {
                response = new BaseCompanyData
                {
                    Status = RequestResult.Success,
                };
                return (response, dane);
            }
            else
            {
                var komunikat = await _client.KomunikatKodAsync(cancellationToken);
                switch (komunikat)
                {
                    case KomunikatKod.KodCaptcha:
                        throw new NotImplementedException(nameof(KomunikatKod.KodCaptcha));
                    case KomunikatKod.DaneSzukajWieleIdentyfikatorow:
                        throw new NotImplementedException(nameof(KomunikatKod.DaneSzukajWieleIdentyfikatorow));
                    case KomunikatKod.NieZnalezionoPodmiotów:
                        response = new BaseCompanyData
                        {
                            Status = RequestResult.NotFound,
                        };
                        return (response, null);
                    case KomunikatKod.BrakUprawnienDoRaportu:
                        response = new BaseCompanyData
                        {
                            Status = RequestResult.ForbiddenReport,
                        };
                        return (response, null);
                    case KomunikatKod.BrakSesji:
                        await _client.ZalogujAsync(cancellationToken);
                        return await DaneSzukajAsync(value, by, cancellationToken);
                    default:
                        throw new NotImplementedException($"{nameof(KomunikatKod)} - other");
                }
            }
        }

        private async Task<(BaseCompanyData Response, FullReport? Report)> PobierzPelnyRaportAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var report = await _client.PobierzPelnyRaportAsync(regon, reportName, cancellationToken);

            BaseCompanyData response;
            if (report is not null)
            {
                response = new BaseCompanyData
                {
                    Status = RequestResult.Success,
                };
                return (response, report);
            }
            else
            {
                var komunikat = await _client.KomunikatKodAsync(cancellationToken);
                switch (komunikat)
                {
                    case KomunikatKod.KodCaptcha:
                        throw new NotImplementedException(nameof(KomunikatKod.KodCaptcha));
                    case KomunikatKod.DaneSzukajWieleIdentyfikatorow:
                        throw new NotImplementedException(nameof(KomunikatKod.DaneSzukajWieleIdentyfikatorow));
                    case KomunikatKod.NieZnalezionoPodmiotów:
                        response = new BaseCompanyData
                        {
                            Status = RequestResult.NotFound,
                        };
                        return (response, null);
                    case KomunikatKod.BrakUprawnienDoRaportu:
                        response = new BaseCompanyData
                        {
                            Status = RequestResult.ForbiddenReport,
                        };
                        return (response, null);
                    case KomunikatKod.BrakSesji:
                        await _client.ZalogujAsync(cancellationToken);
                        return await PobierzPelnyRaportAsync(regon, reportName, cancellationToken);
                    default:
                        throw new NotImplementedException($"{nameof(KomunikatKod)} - other");
                }
            }
        }
        private async Task<(BaseCompanyData Response, IEnumerable<Pkd> PKD)> PobierzPKDAsync(
            string regon,
            string reportName,
            CancellationToken cancellationToken = default)
        {
            var pkd = await _client.PobierzPKDAsync(regon, reportName, cancellationToken);
            BaseCompanyData response;
            if (pkd.Any())
            {
                response = new BaseCompanyData
                {
                    Status = RequestResult.Success,
                };
                return (response, pkd);
            }
            else
            {
                var komunikat = await _client.KomunikatKodAsync(cancellationToken);
                switch (komunikat)
                {
                    case KomunikatKod.KodCaptcha:
                        throw new NotImplementedException(nameof(KomunikatKod.KodCaptcha));
                    case KomunikatKod.DaneSzukajWieleIdentyfikatorow:
                        throw new NotImplementedException(nameof(KomunikatKod.DaneSzukajWieleIdentyfikatorow));
                    case KomunikatKod.NieZnalezionoPodmiotów:
                        response = new BaseCompanyData
                        {
                            Status = RequestResult.NotFound,
                        };
                        return (response, null);
                    case KomunikatKod.BrakUprawnienDoRaportu:
                        response = new BaseCompanyData
                        {
                            Status = RequestResult.ForbiddenReport,
                        };
                        return (response, null);
                    case KomunikatKod.BrakSesji:
                        await _client.ZalogujAsync(cancellationToken);
                        return await PobierzPKDAsync(regon, reportName, cancellationToken);
                    default:
                        throw new NotImplementedException($"{nameof(KomunikatKod)} - other");
                }
            }
        }
    }
}
