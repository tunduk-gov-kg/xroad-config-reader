using System;
using System.Xml.Serialization;

namespace XRoad.GlobalConfiguration.Metadata
{
    [Serializable]
    [XmlRoot("memberClass")]
    public class MemberClass
    {
        [XmlElement("code")] public string Code { get; set; }

        [XmlElement("description")] public string Description { get; set; }
    }
}