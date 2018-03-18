using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using System.Threading.Tasks;
using Newtonsoft.Json;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace IotNotification
{
    public sealed class StartupTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            int led_Pin = 35;
            var gpio = GpioController.GetDefault();

            var a = FindMessage();
            GpioPin pin = gpio.OpenPin(led_Pin);
            pin.SetDriveMode(GpioPinDriveMode.Output);
            pin.Write(GpioPinValue.Low);
            Task.Delay(1000).Wait();
            pin.Write(GpioPinValue.High);
            Task.Delay(1000).Wait();
        }

        private async  Task<bool> FindMessage()
        {
            bool success = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://azure4alexaben.azurewebsites.net/api/iot");
                var response =await client.GetAsync("");
                var result = response.Content.ReadAsStringAsync().Result;
                var account = JsonConvert.DeserializeObject<Account>(result);
                if(account != null){
                    return true;
                }
            }

            return false;
        }
    }
}
