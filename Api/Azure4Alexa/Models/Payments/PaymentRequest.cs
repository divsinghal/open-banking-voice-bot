namespace Azure4Alexa.Models.Payments
{
    public class PaymentRequest
    {
        public To to { get; set; }
        public Value value { get; set; }
        public string description { get; set; }
    }

    public class To
    {
        public string bank_id { get; set; }
        public string account_id { get; set; }
    }

    public class Value
    {
        public string currency { get; set; }
        public string amount { get; set; }
    }
}