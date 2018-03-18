using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;
using Azure4Alexa.Alexa;
using Azure4Alexa.Helper;
using Azure4Alexa.Models.Transactions;
using Session = AlexaSkillsKit.Speechlet.Session;

namespace Azure4Alexa.Santander
{
    public class GetTransactions
    {
        public static async Task<SpeechletResponse> GetResults(Session session, string date)
        {
            var api = new ApiClient();
            var datetimeFrom = DateTime.Parse(date);
            var result = await api.GetAsync<Transactions>(string.Format(Constants.ApiEndpoints.MyTransactions, datetimeFrom, datetimeFrom.AddDays(1)));
            var simpleIntentResponse = ParseResults(result);
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults(Transactions result)
        {
            var spending = result.transactions.Where(x => decimal.Parse(x.details.value.amount) > 0)
                .Sum(x => decimal.Parse(x.details.value.amount)).ToString(CultureInfo.InvariantCulture).Replace(".00", "");
            var stringToRead = $"<speak>There's {result.transactions.Length} transactions and you've spent {spending} pounds</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = string.Empty,
                ssmlString = stringToRead
            };
        }
    }
}