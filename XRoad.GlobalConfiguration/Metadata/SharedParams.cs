using System.Collections.Generic;
using System.Xml.Serialization;

namespace XRoad.GlobalConfiguration.Metadata
{
    [XmlRoot(ElementName = "conf", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    public class SharedParams
    {
        [XmlElement(ElementName = "instanceIdentifier", Namespace = "")]
        public string InstanceIdentifier { get; set; }

        [XmlElement("securityServer", Namespace = "")]
        public List<SecurityServer> SecurityServers { get; set; }

        [XmlElement("member", Namespace = "")] public List<Member> Members { get; set; }
    }
}