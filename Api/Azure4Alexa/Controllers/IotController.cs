using System;
using System.Web.Http;
using System.Threading.Tasks;

namespace Azure4Alexa.Controllers
{
    public class IotController : ApiController
    {
        [HttpGet]
        [Route("api/iot")]
        public async Task<bool> Get()
        {
            try
            {
                var response = await Iot.GetPayments.HasPayment();
                return response;
            }
            catch
            {
                return false;
            }
        }
    }
}
