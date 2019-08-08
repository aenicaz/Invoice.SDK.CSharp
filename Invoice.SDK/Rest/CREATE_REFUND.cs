using System.Collections.Generic;

namespace Invoice.SDK.Rest
{

    public struct CREATE_REFUND
    {
        public string id { get; set; }
        public REFUND_INFO refund { get; set; }
        public List<ITEM> receipt { get; set; }
    }
}
