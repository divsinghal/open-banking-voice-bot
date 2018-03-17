using System.Globalization;
using System.Threading.Tasks;
using AlexaSkillsKit.Speechlet;
using Azure4Alexa.Alexa;
using Azure4Alexa.Helper;
using Azure4Alexa.Models.Payments;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Session = AlexaSkillsKit.Speechlet.Session;

namespace Azure4Alexa.Santander
{
    public class MakePayment
    {
        public static async Task<SpeechletResponse> GetResults(Session session, decimal amount, string accountTo)
        {
            var api = new ApiClient();
            var payment = new PaymentRequest
            {
                description = $"Payment of {amount.ToString(CultureInfo.InvariantCulture) + " pounds"} to {accountTo}",
                to = new To
                {
                    account_id = "LeeCox",
                    bank_id = "santander.01.uk.sanuk"
                },
                value = new Value
                {
                    amount = amount.ToString(CultureInfo.InvariantCulture),
                    currency = "GBP"
                }
            };
            var result = await api.PostAsAsync<PaymentResponse>(Constants.ApiEndpoints.MakePayment, payment);
            var simpleIntentResponse = ParseResults(result);
            await PostToQueue();
            return AlexaUtils.BuildSpeechletResponse(simpleIntentResponse, true);
        }

        private static AlexaUtils.SimpleIntentResponse ParseResults(PaymentResponse result)
        {
            var stringToRead = "<speak><break time=\"1s\" />";
            stringToRead += $"Payment of {result.details.value.amount} pounds made to {result.details.to.account_id} successfully.";
            stringToRead += "</speak>";

            return new AlexaUtils.SimpleIntentResponse
            {
                cardText = string.Empty,
                ssmlString = stringToRead,
            };
        }

        private static async Task PostToQueue()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("paymentqueue");
            queue.CreateIfNotExists();
            CloudQueueMessage message = new CloudQueueMessage("TRUE");
            await queue.AddMessageAsync(message);
        }
    }
}