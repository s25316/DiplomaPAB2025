// Ignore Spelling: Regon, Plugin, Uslugi, Komunikat, Kod, Niepoprawne, Dane, Wejsciowe
using RegonPlugin.Enums;
using RegonPlugin.Enums.GetValues;

namespace RegonPlugin.Models
{
    public class Response<T> where T : class
    {
        public bool HasErrors => Error is not null;
        public RegonError? Error { get; set; } = null;
        public string? ErrorMessage { get; set; } = null;
        public StatusUslugi? StatusUslugi { get; set; }
        public T Value { get; set; } = null!;


        public static Response<T> IsCorrect(T value)
        {
            return new Response<T>
            {
                StatusUslugi = Enums.GetValues.StatusUslugi.UslugaDostepna,
                Value = value,
            };
        }

        public static Response<T> KomunikatKodError(KomunikatKod error)
        {
            return new Response<T>
            {
                StatusUslugi = Enums.GetValues.StatusUslugi.UslugaDostepna,
                Error = (RegonError)((int)error),
            };
        }

        public static Response<T> NiepoprawneDaneWejscioweError(string errorMessage)
        {
            return new Response<T>
            {
                StatusUslugi = null,
                Error = RegonError.NiepoprawneDaneWejsciowe,
                ErrorMessage = errorMessage,
            };
        }

        public static Response<T> UndefinedError(StatusUslugi status)
        {
            return new Response<T>
            {
                Error = RegonError.Inny,
                StatusUslugi = status,
            };
        }

        public static Response<T> ParseErrorResponse<K>(Response<K> baseResponse)
            where K : class
        {
            return new Response<T>
            {
                Error = baseResponse.Error,
                ErrorMessage = baseResponse.ErrorMessage,
                StatusUslugi = baseResponse.StatusUslugi,
            };
        }

    }
}
