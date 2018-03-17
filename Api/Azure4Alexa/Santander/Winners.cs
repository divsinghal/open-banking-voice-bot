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
    public class Winners
    {
        public static async Task<SpeechletResponse> GetResults()
        {
            var api = new ApiClient();
            var simpleIntentResponse = ParseResults();
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults()
        {
            string stringToRead = String.Empty;
            string stringForCard = String.Empty;

            stringToRead += "<speak><break time=\"2s\" /> ";
            stringToRead += $"Voice bot<break time=\"0.5s\" /> obviously</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = stringForCard,
                ssmlString = stringToRead,
            };
        }
    }
}