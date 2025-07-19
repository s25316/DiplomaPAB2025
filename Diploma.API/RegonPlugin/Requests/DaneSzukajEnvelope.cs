// Ignore Spelling: Regon, Plugin, Szukaj,, Krs xmlns, wsa
using RegonPlugin.ValueObjects;

namespace RegonPlugin.Requests
{
    internal readonly record struct DaneSzukajEnvelope
    {
        public string Value { get; }


        public DaneSzukajEnvelope(Krs krs, string endPoint)
        {
            var envelopeParameter = $"<dat:Krs>{(string)krs}</dat:Krs>";
            Value = PrepareEnvelope(envelopeParameter, endPoint);
        }

        public DaneSzukajEnvelope(Nip value, string endPoint)
        {
            var envelopeParameter = $"<dat:Nip>{(string)value}</dat:Nip>";
            Value = PrepareEnvelope(envelopeParameter, endPoint);
        }

        public DaneSzukajEnvelope(Regon value, string endPoint)
        {
            var envelopeParameter = $"<dat:Regon>{(string)value}</dat:Regon>";
            Value = PrepareEnvelope(envelopeParameter, endPoint);
        }


        public static implicit operator string(DaneSzukajEnvelope value) => value.Value;
        public override string ToString() => Value;

        private static string PrepareEnvelope(string envelopeParameter, string endPoint)
        {
            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"" xmlns:dat=""http://CIS/BIR/PUBL/2014/07/DataContract"">
                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                        <wsa:To>{endPoint}</wsa:To>
                        <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj</wsa:Action>
                    </soap:Header>
                    <soap:Body>
                        <ns:DaneSzukaj>
                            <ns:pParametryWyszukiwania>
                                {envelopeParameter}
                            </ns:pParametryWyszukiwania>
                        </ns:DaneSzukaj>
                    </soap:Body>
                    </soap:Envelope>";
        }
    }
}
