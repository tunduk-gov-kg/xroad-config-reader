namespace XRoad.Domain
{
    public class SecurityServerIdentifier : MemberIdentifier
    {
        public string SecurityServerCode { get; set; }

        public override string ToString()
        {
            return $"{Instance}/{MemberClass}/{MemberCode}/{SecurityServerCode}";
        }
    }

    public class SecurityServerData
    {
        public SecurityServerIdentifier SecurityServerIdentifier { get; set; }
        public string Address { get; set; }
    }
}