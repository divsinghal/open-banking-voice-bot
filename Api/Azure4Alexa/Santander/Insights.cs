using System.Globalization;
using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;
using Azure4Alexa.Alexa;
using Azure4Alexa.Helper;
using Azure4Alexa.Models.Accounts;
using Azure4Alexa.Models.SpendingInsights;
using Session = AlexaSkillsKit.Speechlet.Session;

namespace Azure4Alexa.Santander
{
    public class Insights
    {
        public static async Task<SpeechletResponse> GetResults(Session session)
        {
            var result = await GetSpendingInsight();
            var simpleIntentResponse = ParseResults(result);
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        public static async Task<SpendingInsight> GetSpendingInsight()
        {
            var api = new ApiClient();
            var result = await api.GetAsync<SpendingInsight>(Constants.ApiEndpoints.Insights);
            return result;
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults(SpendingInsight result)
        {
            var stringToRead = $"<speak>You spent {(result.Mcdonalds + result.PizzaHut).ToString(CultureInfo.InvariantCulture).Replace(".00", "")} " +
                               "pounds on eating out last month. " +
                               "<break time=\"0.2s\" />I'll remind you to go shopping at the weekend.</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = "",
                ssmlString = stringToRead,
            };
        }
    }
}