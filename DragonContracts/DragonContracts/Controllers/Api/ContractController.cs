using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DragonContracts.Base;
using DragonContracts.Models;

namespace DragonContracts.Controllers.Api
{
    public class ContractController : DragonContractsController
    {
        // GET api/contract
        public Contract Get()
        {
            return new Contract();
        }

        // GET api/contract/5
        public async Task<Contract> Get(string id)
        {
            return await Session.LoadAsync<Contract>(id);
        }

        // POST api/values
        public async Task<HttpResponseMessage> Post([FromBody]Contract value)
        {
            await Session.StoreAsync(value);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT api/values/5
        public async Task<HttpResponseMessage> Put(string id, [FromBody]Contract value)
        {
            await Session.StoreAsync(value, id);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE api/values/5
        public void Delete(string id)
        {
            Session.Advanced.DocumentStore.DatabaseCommands.Delete(id, null);
        }
    }
}
