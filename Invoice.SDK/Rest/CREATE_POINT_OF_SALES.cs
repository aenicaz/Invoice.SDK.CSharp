using System;

namespace Invoice.SDK.Rest
{
    public struct CREATE_POINT_OF_SALES
    {
        public string name;
        public string address;
        public string alias;
        public string mail;
        public string phone;
        public PAYMENT_POINT_TYPE type;
        public Uri website;
    }
}
