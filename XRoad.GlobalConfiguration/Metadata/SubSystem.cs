using System;
using System.Xml.Serialization;

namespace XRoad.GlobalConfiguration.Metadata
{
    [Serializable]
    [XmlRoot("subsystem")]
    public class SubSystem
    {
        [XmlAttribute("id")] public string Id { get; set; }

        [XmlElement("subsystemCode")] public string SubSystemCode { get; set; }
    }
}