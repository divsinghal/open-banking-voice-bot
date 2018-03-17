using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure4Alexa.Models
{
    public class Transactions
    {
        public Transaction[] transactions { get; set; }
    }

    public class Transaction
    {
        public string id { get; set; }
        public This_Account this_account { get; set; }
        public Other_Account other_account { get; set; }
        public Details details { get; set; }
        public Metadata1 metadata { get; set; }
    }

    public class This_Account
    {
        public string id { get; set; }
        public Bank_Routing bank_routing { get; set; }
        public Account_Routing account_routing { get; set; }
        public Holder[] holders { get; set; }
    }

    public class Bank_Routing
    {
        public string scheme { get; set; }
        public string address { get; set; }
    }

    public class Account_Routing
    {
        public string scheme { get; set; }
        public string address { get; set; }
    }

    public class Holder
    {
        public string name { get; set; }
        public bool is_alias { get; set; }
    }

    public class Other_Account
    {
        public string id { get; set; }
        public Holder1 holder { get; set; }
        public Bank_Routing1 bank_routing { get; set; }
        public Account_Routing1 account_routing { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Holder1
    {
        public string name { get; set; }
        public bool is_alias { get; set; }
    }

    public class Bank_Routing1
    {
        public string scheme { get; set; }
        public string address { get; set; }
    }

    public class Account_Routing1
    {
        public string scheme { get; set; }
        public string address { get; set; }
    }

    public class Metadata
    {
        public string public_alias { get; set; }
        public object private_alias { get; set; }
        public object more_info { get; set; }
        public object URL { get; set; }
        public object image_URL { get; set; }
        public object open_corporates_URL { get; set; }
        public object corporate_location { get; set; }
        public object physical_location { get; set; }
    }

    public class Details
    {
        public string type { get; set; }
        public string description { get; set; }
        public DateTime posted { get; set; }
        public DateTime completed { get; set; }
        public New_Balance new_balance { get; set; }
        public Value value { get; set; }
    }

    public class New_Balance
    {
        public string currency { get; set; }
        public string amount { get; set; }
    }

    public class Value
    {
        public string currency { get; set; }
        public string amount { get; set; }
    }

    public class Metadata1
    {
        public object narrative { get; set; }
        public object[] comments { get; set; }
        public object[] tags { get; set; }
        public object[] images { get; set; }
        public object where { get; set; }
    }

}