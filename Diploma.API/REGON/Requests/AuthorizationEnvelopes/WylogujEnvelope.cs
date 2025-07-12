// Ignore Spelling: Regon, Wyloguj
namespace REGON.Requests.AuthorizationEnvelopes
{
    internal readonly record struct WylogujEnvelope
    {
        // Property
        public readonly string Value { get; }


        // Constructor
        public WylogujEnvelope(string sessionId, string endPoint)
        {
            Value = $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                        <wsa:To>{endPoint}</wsa:To>
                        <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj</wsa:Action>
                    </soap:Header>
                    <soap:Body>
                        <ns:Wyloguj>
                            <ns:pIdentyfikatorSesji>{sessionId}</ns:pIdentyfikatorSesji>
                        </ns:Wyloguj>
                    </soap:Body>
                    </soap:Envelope>";
        }


        // Methods
        public static implicit operator string(WylogujEnvelope envelope) => envelope.Value;
        public override string ToString() => Value;
    }
}
