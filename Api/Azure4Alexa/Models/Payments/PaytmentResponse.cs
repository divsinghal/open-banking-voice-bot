using System;

namespace Azure4Alexa.Models.Payments
{
    public class PaymentResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public From from { get; set; }
        public Details details { get; set; }
        public string[] transaction_ids { get; set; }
        public string status { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public object challenge { get; set; }
        public Charge charge { get; set; }
    }

    public class From
    {
        public string bank_id { get; set; }
        public string account_id { get; set; }
    }

    public class Details
    {
        public To to { get; set; }
        public Transactions.Value value { get; set; }
        public string description { get; set; }
    }

    public class Charge
    {
        public string summary { get; set; }
        public Value1 value { get; set; }
    }

    public class Value1
    {
        public string currency { get; set; }
        public string amount { get; set; }
    }

}