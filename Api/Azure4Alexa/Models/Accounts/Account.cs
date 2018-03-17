namespace Azure4Alexa.Models.Accounts
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

    public class AccountRoutings
    {
        public string scheme { get; set; }
        public string address { get; set; }
    }

    public class Balance
    {
        public string currency { get; set; }
        public string amount { get; set; }
    }

    public class Owner
    {
        public string id { get; set; }
        public string provider { get; set; }
        public string display_name { get; set; }
    }
}