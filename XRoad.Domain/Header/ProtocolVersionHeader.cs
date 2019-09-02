using System.Xml.Serialization;
using SimpleSOAPClient.Models;

namespace XRoad.Domain.Header
{
    [XmlRoot(ElementName = "protocolVersion", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    public class ProtocolVersionHeader : SoapHeader
    {
        [XmlText] public string Value { get; set; }

        public static ProtocolVersionHeader Version40 => new ProtocolVersionHeader
        {
            Value = "4.0"
        };
    }
}