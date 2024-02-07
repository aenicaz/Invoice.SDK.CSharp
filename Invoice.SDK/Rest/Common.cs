using System;

namespace Invoice.SDK.Rest
{
    public struct ORDER
    {
        public string currency { get; set; }
        public double amount { get; set; }
        public string description { get; set; }
        public string id { get; set; }
    }

    public struct SETTINGS
    {
        public string terminal_id { get; set; }
        public Uri success_url { get; set; }
        public Uri fail_url { get; set; }
        public string recur_exp { get; set; }
        public string recur_freq { get; set; }        
    }

    public struct RECEIPT
    {
        public string name { get; set; }
        public double price { get; set; }
        public string discount { get; set; }
        public double resultPrice { get; set; }
        public float quantity { get; set; }
    }
    public struct PAYMENT_METHOD
    {
        public string account {  get; set; }
        public string type { get; set; }
        public string terminal_id { get; set; }
    }
    public struct REFUND
    {
        public double amount { get; set; }
        public string reason { get; set; }
    }
    public enum RT_TYPE
    {
        payment = 1,
        paymentWithRecurentRegistration = 4
    }
    public enum NOTIFICATION_TYPE
    {
        pay,
        check
    }

    public enum TERMINAL_TYPE
    {
        statical,
        dynamical
    }
    public enum STATUS
    {
        init,
        process,
        successful,
        error
    }
    public enum PAYMENT_POINT_TYPE
    {
        offline,
        online
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
