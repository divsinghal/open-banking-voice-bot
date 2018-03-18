using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;
using Azure4Alexa.Alexa;
using Azure4Alexa.Helper;
using Azure4Alexa.Models.Accounts;
using Session = AlexaSkillsKit.Speechlet.Session;

namespace Azure4Alexa.Santander
{
    public class GetBalance
    {
        public static async Task<SpeechletResponse> GetResults(Session session)
        {
            var result = await GetBalanceFromOpenBanking();
            var simpleIntentResponse = ParseResults(result);
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        public static async Task<Account> GetBalanceFromOpenBanking()
        {
            var api = new ApiClient();
            var result = await api.GetAsync<Account>(Constants.ApiEndpoints.MyAccount);
            return result;
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults(Account result)
        {
            var stringToRead = $"<speak>Your balance is {result.balance.amount.Replace(".00", "")} pounds.</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = "",
                ssmlString = stringToRead,
            };
        }
    }
}