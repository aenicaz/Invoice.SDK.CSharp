using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.SDK.Rest
{
    public struct CREATE_TERMINAL
    {
        public string alias;
        public string name;
        public string description;
        public TERMINAL_TYPE type;
        public double defaultPrice;
    }
}
