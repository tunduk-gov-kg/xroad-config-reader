using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XRoad.GlobalConfiguration.Metadata
{
    [Serializable]
    [XmlRoot("securityServer", Namespace = "")]
    public class SecurityServer
    {
        [XmlElement("owner", Namespace = "")] public string Owner { get; set; }

        [XmlElement("serverCode", Namespace = "")]
        public string ServerCode { get; set; }

        [XmlElement("address", Namespace = "")]
        public string Address { get; set; }

        [XmlElement("client", Namespace = "")] public List<string> Clients { get; set; }
    }
}