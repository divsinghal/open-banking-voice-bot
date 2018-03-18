using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure4Alexa.Constants
{
    public class ApiEndpoints
    {
        public const string Insights = "https://sant1.herokuapp.com/restaurants/12";

        public const string MyAccount = "https://santander.openbankproject.com/obp/v3.0.0/my/banks/santander.01.uk.sanuk/accounts/110484617/account";
        public const string MyTransactions = "https://santander.openbankproject.com/obp/v3.0.0/banks/santander.01.uk.sanuk/accounts/110484617/owner/transactions?from_date={0:yyyy-MM-dd}&to_date={1:yyyy-MM-dd}";
        public const string MakePayment = "https://santander.openbankproject.com/obp/v3.0.0/banks/santander.01.uk.sanuk/accounts/110484617/owner/transaction-request-types/SANDBOX_TAN/transaction-requests";
    }
}