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
            var simpleIntentResponse = ParseResults();
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults()
        {
            var stringToRead = "<speak>Voice bot<break time=\"0.2s\" />obviously</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = "",
                ssmlString = stringToRead,
            };
        }
    }
}