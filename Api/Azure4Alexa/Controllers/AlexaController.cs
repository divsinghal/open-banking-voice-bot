using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Azure4Alexa.Alexa;

namespace Azure4Alexa.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> AlexaSession()
        {
            var alexaSpeechletAsync = new Alexa.AlexaSpeechletAsync();
            return await alexaSpeechletAsync.GetResponseAsync(Request);
        }
    }
}

