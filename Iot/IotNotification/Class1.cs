namespace IotNotification
{
    public sealed class Account
    {
        public string id { get; set; }
        public string bank_id { get; set; }
        public object label { get; set; }
        public string number { get; set; }
        public object type { get; set; }
        public object[] account_rules { get; set; }
    }
}