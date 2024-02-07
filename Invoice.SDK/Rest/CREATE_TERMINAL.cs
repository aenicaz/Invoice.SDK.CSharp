namespace Invoice.SDK.Rest
{
    public struct CREATE_TERMINAL
    {
        public string name;
        public string alias;
        public string description;
        public TERMINAL_TYPE type;
        public double defaultPrice;
        public string pointId;
    }
}
