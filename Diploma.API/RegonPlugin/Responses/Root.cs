// Ignore Spelling: Regon, Plugin, dane
using System.Xml.Serialization;

namespace RegonPlugin.Responses
{
    [XmlRoot(ElementName = "root", Namespace = "http://CIS/BIR/PUBL/2014/07", IsNullable = false)]
    public class Root<T>
        where T : class
    {
        [XmlElement(ElementName = "dane")]
        public List<T> Dane { get; init; } = [];
    }
}
