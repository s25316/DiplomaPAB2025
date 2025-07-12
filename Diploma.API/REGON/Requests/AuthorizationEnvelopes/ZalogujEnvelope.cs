// Ignore Spelling: Regon, Zaloguj
using REGON.ValueObjects;

namespace REGON.Requests.AuthorizationEnvelopes
{
    internal readonly record struct ZalogujEnvelope
    {
        // Property
        public readonly string Value { get; }


        // Constructor
        public ZalogujEnvelope(UserKey key, string endPoint)
        {
            Value = $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                        <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj</wsa:Action>
                        <wsa:To>{endPoint}</wsa:To>
                    </soap:Header>
                    <soap:Body>
                        <ns:Zaloguj>
                            <ns:pKluczUzytkownika>{(string)key}</ns:pKluczUzytkownika>
                        </ns:Zaloguj>
                    </soap:Body>
                    </soap:Envelope>";
        }


        // Methods
        public static implicit operator string(ZalogujEnvelope envelope) => envelope.Value;
        public override string ToString() => Value;
    }
}
