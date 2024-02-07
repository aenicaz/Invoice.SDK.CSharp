using System.Collections.Generic;

namespace Invoice.SDK.Rest
{
    public struct CREATE_REFUND
    {
        public string id { get; set; }
        public REFUND refund { get; set; }
        public List<RECEIPT> receipts { get; set; }
    }
}
