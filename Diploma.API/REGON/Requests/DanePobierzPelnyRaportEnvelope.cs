// Ignore Spelling: REGON, Pobierz, Pelny, Raport

namespace REGON.Requests
{
    internal record struct DanePobierzPelnyRaportEnvelope
    {
        // Properties
        public string Value { get; }


        // Constructor
        public DanePobierzPelnyRaportEnvelope(
            string regon,
            string reportName,
            string endPoint)
        {
            Value = $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                    <wsa:To>{endPoint}</wsa:To>
                    <wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaport</wsa:Action>            
                    </soap:Header>
                      <soap:Body>
                          <ns:DanePobierzPelnyRaport>
                             <ns:pRegon>{regon}</ns:pRegon>         
                             <ns:pNazwaRaportu>{reportName}</ns:pNazwaRaportu>
                          </ns:DanePobierzPelnyRaport>
                       </soap:Body>
                    </soap:Envelope>";
        }


        // Methods
        public static implicit operator string(DanePobierzPelnyRaportEnvelope envelope) => envelope.Value;
        public override string ToString() => Value;
    }
}
