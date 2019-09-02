using System.Xml.Serialization;

namespace XRoad.Domain.Header
{
    public enum ObjectType
    {
        [XmlEnum(Name = "SERVICE")] Service,

        [XmlEnum(Name = "SUBSYSTEM")] SubSystem,

        [XmlEnum(Name = "MEMBER")] Member,

        [XmlEnum(Name = "SERVER")] Server
    }
}