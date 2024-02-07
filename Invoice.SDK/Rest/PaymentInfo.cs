using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Invoice.SDK.Rest
{
    public struct PaymentInfo
    {
        public string id { get; set; }
        public ORDER order { get; set; }
        public PAYMENT_STATE status { get; set; }
        public string status_description { get; set; }
        public PAYMENT_METHOD payment_method { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public DateTime expire_date { get; set; }
        public Dictionary<string, JToken> custom_parameters { get; set; }
        public string payment_url { get; set; }
    }
}
