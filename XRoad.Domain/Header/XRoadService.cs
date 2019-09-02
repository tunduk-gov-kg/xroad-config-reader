using System.Xml.Serialization;
using SimpleSOAPClient.Models;

namespace XRoad.Domain.Header
{
    [XmlRoot(ElementName = "service", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    public class XRoadService : SoapHeader
    {
        [XmlAttribute(AttributeName = "objectType", Namespace = "http://x-road.eu/xsd/identifiers")]
        public ObjectType ObjectType
        {
            get => ObjectType.Service;
            // ReSharper disable once ValueParameterNotUsed
            set { }
        }

        [XmlElement(ElementName = "xRoadInstance", IsNullable = false, Namespace = "http://x-road.eu/xsd/identifiers")]
        public string Instance { get; set; }

        [XmlElement(ElementName = "memberClass", IsNullable = false, Namespace = "http://x-road.eu/xsd/identifiers")]
        public string MemberClass { get; set; }

        [XmlElement(ElementName = "memberCode", IsNullable = false, Namespace = "http://x-road.eu/xsd/identifiers")]
        public string MemberCode { get; set; }

        [XmlElement(ElementName = "subsystemCode", IsNullable = true, Namespace = "http://x-road.eu/xsd/identifiers")]
        public string SubSystemCode { get; set; }

        [XmlElement(ElementName = "serviceCode", IsNullable = false, Namespace = "http://x-road.eu/xsd/identifiers")]
        public string ServiceCode { get; set; }

        [XmlElement(ElementName = "serviceVersion", IsNullable = true, Namespace = "http://x-road.eu/xsd/identifiers")]
        public string ServiceVersion { get; set; }

        [XmlIgnore] public bool SubSystemCodeSpecified => SubSystemCode != null;

        [XmlIgnore] public bool ServiceVersionSpecified => ServiceVersion != null;

        public static implicit operator XRoadService(ServiceIdentifier service)
        {
            return new XRoadService
            {
                Instance = service.Instance,
                MemberClass = service.MemberClass,
                MemberCode = service.MemberCode,
                SubSystemCode = service.SubSystemCode,
                ServiceCode = service.ServiceCode,
                ServiceVersion = service.ServiceVersion
            };
        }
    }
}