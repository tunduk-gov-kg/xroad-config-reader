namespace XRoad.Domain
{
    public class SubSystemIdentifier : MemberIdentifier
    {
        public string SubSystemCode { get; set; }

        protected bool Equals(SubSystemIdentifier other)
        {
            return base.Equals(other) && string.Equals(SubSystemCode, other.SubSystemCode);
        }

        public override string ToString()
        {
            return $"{base.ToString()}/{SubSystemCode}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SubSystemIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (SubSystemCode != null ? SubSystemCode.GetHashCode() : 0);
            }
        }
    }
}