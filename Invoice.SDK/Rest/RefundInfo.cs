using System;

namespace Invoice.SDK.Rest
{
    public struct RefundInfo
    {
        public string id { get; set; }
        public ORDER order { get; set; }
        public REFUND refund { get; set; }
        public string payment_id { get; set; }
        public PAYMENT_METHOD payment_method { get; set; }
        public DateTime date_insert { get; set; }
        public DateTime date_update { get; set; }
        public STATUS status { get; set; }
    }
}
