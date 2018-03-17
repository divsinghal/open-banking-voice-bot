using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using Azure4Alexa.Helper;
using Azure4Alexa.Models;

namespace Azure4Alexa.Controllers
{
    public class AlexaController : ApiController
    {
       // you can set an explicit route if you want ...
       // [Route("alexa/alexa-session")]
        [HttpPost]
        public async Task<HttpResponseMessage> AlexaSession()
        {
            try
            {
                var alexaSpeechletAsync = new Alexa.AlexaSpeechletAsync();
                return await alexaSpeechletAsync.GetResponseAsync(Request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}

