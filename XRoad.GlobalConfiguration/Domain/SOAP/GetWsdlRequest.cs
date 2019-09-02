using System.Xml.Serialization;

namespace XRoad.GlobalConfiguration.Domain.SOAP
{
    [XmlRoot(ElementName = "getWsdl", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    public class GetWsdlRequest
    {
        [XmlElement(ElementName = "serviceCode", IsNullable = false, Namespace = "http://x-road.eu/xsd/xroad.xsd")]
        public string ServiceCode { get; set; }

        [XmlElement(ElementName = "serviceVersion", IsNullable = true, Namespace = "http://x-road.eu/xsd/xroad.xsd")]
        public string ServiceVersion { get; set; }

        [XmlIgnore] public bool ServiceVersionSpecified => null != ServiceVersion;
    }
}