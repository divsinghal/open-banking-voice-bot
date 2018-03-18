using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace IotNotification
{
    public sealed class StartupTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            int led_Pin = 35;
            var gpio = GpioController.GetDefault();
            GpioPin pin = gpio.OpenPin(led_Pin);
            pin.SetDriveMode(GpioPinDriveMode.Output);

            while (true)
            {
                Task<bool> task = Task.Run(() => FindMessage());

                // Will block until the task is completed...
                bool result = task.Result;
                if (result)
                {
                    pin.Write(GpioPinValue.High);
                    Task.Delay(5000).Wait();
                }
                else
                {
                    pin.Write(GpioPinValue.Low);
                    Task.Delay(5000).Wait();
                }
            }


        }

        private async  Task<bool> FindMessage()
        {
            bool success = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://azure4alexaben.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync("api/iot");
                    var result = response.Content.ReadAsStringAsync().Result;
                    var account = JsonConvert.DeserializeObject<bool>(result);
                    if (account != null)
                    {
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                ex = ex;
            }

            return false;
        }
    }
}
