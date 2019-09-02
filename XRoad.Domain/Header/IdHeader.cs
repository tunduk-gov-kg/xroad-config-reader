using System;
using System.Xml.Serialization;
using SimpleSOAPClient.Models;

namespace XRoad.Domain.Header
{
    [XmlRoot(ElementName = "id", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    public class IdHeader : SoapHeader
    {
        [XmlText] public string Value { get; set; }

        public static IdHeader Random => new IdHeader
        {
            Value = Guid.NewGuid().ToString()
        };
    }
}