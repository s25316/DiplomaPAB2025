// Ignore Spelling: Regon
using REGON.Enums.GetValues;

namespace REGON.Requests
{
    internal readonly record struct GetValueEnvelope
    {
        // Fields
        private readonly Dictionary<GetValue, string> _parameters = new()
        {
            { GetValue.StanDanych, "StanDanych"},

            { GetValue.KomunikatKod, "KomunikatKod"},
            { GetValue.KomunikatTresc, "KomunikatTresc"},

            { GetValue.StatusSesji, "StatusSesji"},

            { GetValue.StatusUslugi, "StatusUslugi"},
            { GetValue.KomunikatUslugi, "KomunikatUslugi"},
        };

        // Properties
        public string Value { get; }


        // Constructor
        public GetValueEnvelope(GetValue type, string endPoint)
        {
            Value = $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/2014/07"">
                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                    <wsa:To>{endPoint}</wsa:To>
                    <wsa:Action>http://CIS/BIR/2014/07/IUslugaBIR/GetValue</wsa:Action>
                    </soap:Header>
                       <soap:Body>
                          <ns:GetValue>
                             <ns:pNazwaParametru>{_parameters[type]}</ns:pNazwaParametru>
                          </ns:GetValue>
                       </soap:Body>
                    </soap:Envelope>";
        }


        // Methods
        public static implicit operator string(GetValueEnvelope envelope) => envelope.Value;
        public override string ToString() => Value;
    }
}
