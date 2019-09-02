using System.Collections.Generic;
using System.Xml.Serialization;
using XRoad.Domain.Header;

namespace XRoad.GlobalConfiguration.Domain.SOAP
{
    [XmlRoot(ElementName = "listMethodsResponse", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    public class ListMethodsResponse
    {
        [XmlElement(ElementName = "service", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
        public List<XRoadService> Services { get; set; }
    }
}