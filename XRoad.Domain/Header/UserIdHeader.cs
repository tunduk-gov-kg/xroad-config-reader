using System.Xml.Serialization;
using SimpleSOAPClient.Models;

namespace XRoad.Domain.Header
{
    [XmlRoot(ElementName = "userId", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    public class UserIdHeader : SoapHeader
    {
        [XmlText] public string Value { get; set; }
    }
}