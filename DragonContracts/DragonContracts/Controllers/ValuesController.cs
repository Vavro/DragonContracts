using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DragonContracts.Base;
using DragonContracts.Models;
using Raven.Client;

namespace DragonContracts.Controllers
{
    public class ContractsController : RavenDbController
    {
        // GET api/values
        public Task<IList<Contract>> Get()
        {
            return Session.Query<Contract>().ToListAsync();
        }

        // GET api/values/5
        public async Task<Contract> Get(int id)
        {
            return await Session.LoadAsync<Contract>(id.ToString());
        }

        // POST api/values
        public async Task<HttpResponseMessage> Post([FromBody]Contract value)
        {
            await Session.StoreAsync(value, value.Id.ToString());

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT api/values/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]Contract value)
        {
            await Session.StoreAsync(value, id.ToString());

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Session.Advanced.DocumentStore.DatabaseCommands.Delete(id.ToString(), null);
        }
    }
}