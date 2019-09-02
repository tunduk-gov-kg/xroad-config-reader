using XRoad.Domain.Header;

namespace XRoad.Domain
{
    public class ServiceIdentifier : SubSystemIdentifier
    {
        public string ServiceCode { get; set; }
        public string ServiceVersion { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}/{ServiceCode}/{ServiceVersion}";
        }

        protected bool Equals(ServiceIdentifier other)
        {
            return base.Equals(other) && string.Equals(ServiceCode, other.ServiceCode) &&
                   string.Equals(ServiceVersion, other.ServiceVersion);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ServiceIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (ServiceCode != null ? ServiceCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ServiceVersion != null ? ServiceVersion.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static implicit operator ServiceIdentifier(XRoadService xRoadService)
        {
            return new ServiceIdentifier
            {
                Instance = xRoadService.Instance,
                MemberClass = xRoadService.MemberClass,
                MemberCode = xRoadService.MemberCode,
                SubSystemCode = xRoadService.SubSystemCode,
                ServiceCode = xRoadService.ServiceCode,
                ServiceVersion = xRoadService.ServiceVersion
            };
        }
    }
}