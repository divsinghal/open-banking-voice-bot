using System;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.Authentication;
using AlexaSkillsKit.Json;
using System.Threading.Tasks;
using System.Net.Http;
using Azure4Alexa.Models.SpendingInsights;
using Azure4Alexa.Santander;
using Session = AlexaSkillsKit.Speechlet.Session;

namespace Azure4Alexa.Alexa
{
    public class AlexaSpeechletAsync : SpeechletAsync
    {
        //#if DEBUG

        public override bool OnRequestValidation(SpeechletRequestValidationResult result, DateTime referenceTimeUtc, SpeechletRequestEnvelope requestEnvelope)
        {
            return true;
        }

        //#endif

        public override Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session)
        {
            if (AlexaUtils.IsRequestInvalid(session))
            {
                return Task.FromResult<SpeechletResponse>(InvalidApplicationId(session));
            }
            return Task.Delay(0);
        }

        public override Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session)
        { 
            if (AlexaUtils.IsRequestInvalid(session))
            {
                return Task.FromResult<SpeechletResponse>(InvalidApplicationId(session));
            }
            return Task.Delay(0);
        }

        public override async Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session)
        {
            if (AlexaUtils.IsRequestInvalid(session))
            {
                return await Task.FromResult<SpeechletResponse>(InvalidApplicationId(session));
            }

            return await Task.FromResult<SpeechletResponse>(GetOnLaunchAsyncResult(session));
        }
        public override async Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session)
        {

            if (AlexaUtils.IsRequestInvalid(session))
            {
                return await Task.FromResult<SpeechletResponse>(InvalidApplicationId(session));
            }

            var intent = intentRequest.Intent;
            var intentName = intent?.Name;

            switch (intentName.ToUpper())
            {
                case "BALANCE":
                    return await GetBalance.GetResults(session);
                case "TRANSACTIONS":
                    return await GetTransactions.GetResults(session, intentRequest.Intent.Slots["date"].Value);
                case "PAYMENT":
                    return await MakePayment.GetResults(session, decimal.Parse(intentRequest.Intent.Slots["amount"].Value), intentRequest.Intent.Slots["account"].Value);
                case "WINNERS":
                    return await Winners.GetResults();
                case "MORTGAGE":
                    return await Mortgage.GetResults(session);
                case "SAVINGS":
                    return await Insights.GetResults(session);
                default:
                    return await Task.FromResult<SpeechletResponse>(GetOnLaunchAsyncResult(session));
            }

        }

        private SpeechletResponse GetOnLaunchAsyncResult(Session session)
        {
            return AlexaUtils.BuildSpeechletResponse(new AlexaUtils.SimpleIntentResponse
            {
                cardText = "",
                ssmlString = "<speak>Voice bot<break time=\"0.2s\" />obviously</speak>"
            }, true);
        }


        private SpeechletResponse InvalidApplicationId(Session session)
        {
            return AlexaUtils.BuildSpeechletResponse(new AlexaUtils.SimpleIntentResponse()
            {
                cardText = "An invalid Application ID was received from Alexa.  Please update your Visual Studio project " +
                    "to include the correct value and then re-deploy your Azure project."
            }, true);
        }
    }
}