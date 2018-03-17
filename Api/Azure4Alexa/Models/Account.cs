namespace Azure4Alexa.Models
{
    public class Account
    {
        public string id { get; set; }
        public string bank_id { get; set; }
        public object label { get; set; }
        public string number { get; set; }
        public Owner[] owners { get; set; }
        public object type { get; set; }
        public Balance balance { get; set; }
        public AccountRoutings[] account_routings { get; set; }
        public object[] account_rules { get; set; }
    }
}