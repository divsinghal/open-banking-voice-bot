using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;
using Azure4Alexa.Alexa;

namespace Azure4Alexa.Santander
{
    public class Mortgage
    {
        public static async Task<SpeechletResponse> GetResults()
        {
            var simpleIntentResponse = ParseResults();
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults()
        {
            var stringToRead = "<speak>Your mortgage balance is 100 thousand pounds with an interest rate of 2.5 percent<break time=\"0.2s\" />" +
                               "if you over pay by 200 pounds a month you'll be mortgage free 5 years earlier</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = "",
                ssmlString = stringToRead,
            };
        }
    }
}