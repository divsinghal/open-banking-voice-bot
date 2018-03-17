using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AlexaSkillsKit.Speechlet;
using Azure4Alexa.Alexa;
using Azure4Alexa.Helper;
using Azure4Alexa.Models;
using Azure4Alexa.Models.Accounts;
using Newtonsoft.Json.Linq;
using Session = AlexaSkillsKit.Speechlet.Session;

namespace Azure4Alexa.Santander
{
    public class GetBalance
    {
        public static async Task<SpeechletResponse> GetResults(Session session)
        {
            var api = new ApiClient();
            var result = await api.GetAsync<Account>(Constants.ApiEndpoints.MyAccount);
            var simpleIntentResponse = ParseResults(result);
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults(Account result)
        {
            string stringToRead = String.Empty;
            string stringForCard = String.Empty;

            stringToRead += "<speak><break time=\"2s\" /> ";
            stringToRead += $"Your account balance is {result.balance.amount} pounds.</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = stringForCard,
                ssmlString = stringToRead,
            };
        }
    }
}