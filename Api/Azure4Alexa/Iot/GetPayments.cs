using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Azure4Alexa.Iot
{
    public class GetPayments
    {
        public static async Task<bool> HasPayment()
        {
            var storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("paymentqueue");
            var retrievedMessage = await queue.GetMessageAsync();

            if (retrievedMessage != null)
            {
                await queue.DeleteMessageAsync(retrievedMessage);
                return true;
            }
            return false;
        }
    }
}