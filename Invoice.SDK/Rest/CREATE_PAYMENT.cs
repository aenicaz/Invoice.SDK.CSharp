﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Invoice.SDK.Rest
{
    public struct CREATE_PAYMENT
    {
        public ORDER order { get; set; }
        public SETTINGS settings { get; set; }
        public Dictionary<string, JToken> custom_parameters { get; set; }
        public List<RECEIPT> receipt { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int trtype { get; set; }
    }
}
