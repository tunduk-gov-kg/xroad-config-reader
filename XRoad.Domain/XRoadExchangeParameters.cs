using System;

namespace XRoad.Domain
{
    public class XRoadExchangeParameters
    {
        public Uri SecurityServerUri { get; set; }
        public SubSystemIdentifier ClientSubSystem { get; set; }
    }
}