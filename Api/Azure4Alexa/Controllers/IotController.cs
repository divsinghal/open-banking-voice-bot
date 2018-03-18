using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Azure4Alexa.Controllers
{
    public class IotController : ApiController
    {
        [HttpGet]
        public Task<Models.Accounts.Account> Get()
        {
            var response =  Azure4Alexa.Santander.GetBalance.GetBalanceFromOpenBanking();
            return response;
        }
    }
}
