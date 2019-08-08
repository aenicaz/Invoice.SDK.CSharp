using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.SDK.Rest
{
    public struct ORDER
    {
        public string currency { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public string id { get; set; }
    }

    public struct SETTINGS
    {
        public string terminal_id { get; set; }
        public PAYMENT_METHOD_TYPE payment_method { get; set; }
        public Uri success_url { get; set; }
        public Uri fail_url { get; set; }
    }

    public struct ITEM
    {
        public string name { get; set; }
        public float quantity { get; set; }
        public decimal price { get; set; }
        public decimal resultPrice { get; set; }
        public string discount { get; set; }
    }

    public struct REFUND_INFO
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string reason { get; set; }
    }

    public struct PAYMENT_METHOD
    {
        public string terminal_id { get; set; }
        public PAYMENT_METHOD_TYPE type { get; set; }
        public string account { get; set; }
        public double funds { get; set; }
        public double bonuses { get; set; }
    }

    public enum NOTIFICATION_TYPE
    {
        pay,
        check
    }

    public enum PAYMENT_METHOD_TYPE
    {
        card,
        phone,
        qiwi,
        wm
    }

    public enum TERMINAL_TYPE
    {
        statical,
        dynamical
    }

    public enum PAYMENT_STATE
    {
        created = 1,
        init = 2,
        process = 3,
        successful = 4,
        closed = 5,
        error = 0
    }
}
