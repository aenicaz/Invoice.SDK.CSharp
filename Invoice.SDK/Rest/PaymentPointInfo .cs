using System;

namespace Invoice.SDK.Rest
{
    public struct PointOfSaleInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string alias { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public PAYMENT_POINT_TYPE type { get; set; }
        public Uri website { get; set; }
    }
}
