using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using SimpleSOAPClient.Models;

namespace XRoad.Domain.Header
{
    [XmlRoot(ElementName = "client", Namespace = "http://x-road.eu/xsd/xroad.xsd")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class XRoadClient : SoapHeader
    {
        [XmlAttribute(AttributeName = "objectType", Namespace = "http://x-road.eu/xsd/identifiers")]
        public ObjectType ObjectType
        {
            get => null == SubSystemCode ? ObjectType.Member : ObjectType.SubSystem;
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

        [XmlIgnore] public bool SubSystemCodeSpecified => SubSystemCode != null;

        public static implicit operator XRoadClient(SubSystemIdentifier subSystem)
        {
            return new XRoadClient
            {
                Instance = subSystem.Instance,
                MemberClass = subSystem.MemberClass,
                MemberCode = subSystem.MemberCode,
                SubSystemCode = subSystem.SubSystemCode
            };
        }

        public static implicit operator XRoadClient(MemberIdentifier member)
        {
            return new XRoadClient
            {
                Instance = member.Instance,
                MemberClass = member.MemberClass,
                MemberCode = member.MemberCode
            };
        }
    }
}