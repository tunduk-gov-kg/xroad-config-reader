using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XRoad.GlobalConfiguration.Metadata
{
    [Serializable]
    [XmlRoot("member")]
    public class Member
    {
        [XmlAttribute("id")] public string Id { get; set; }

        [XmlElement("name")] public string Name { get; set; }

        [XmlElement("memberCode")] public string MemberCode { get; set; }

        [XmlElement(ElementName = "memberClass")]
        public MemberClass MemberClass { get; set; }

        [XmlElement("subsystem")] public List<SubSystem> SubSystems { get; set; }
    }
}