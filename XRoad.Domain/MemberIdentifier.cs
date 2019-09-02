namespace XRoad.Domain
{
    public class MemberIdentifier
    {
        public string Instance { get; set; }
        public string MemberClass { get; set; }
        public string MemberCode { get; set; }

        public override string ToString()
        {
            return $"{Instance}/{MemberClass}/{MemberCode}";
        }

        protected bool Equals(MemberIdentifier other)
        {
            return string.Equals(Instance, other.Instance) && string.Equals(MemberClass, other.MemberClass) &&
                   string.Equals(MemberCode, other.MemberCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MemberIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Instance.GetHashCode();
                hashCode = (hashCode * 397) ^ MemberClass.GetHashCode();
                hashCode = (hashCode * 397) ^ MemberCode.GetHashCode();
                return hashCode;
            }
        }
    }

    public class MemberData
    {
        public MemberIdentifier MemberIdentifier { get; set; }
        public string Name { get; set; }
    }
}