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
    public class ContractsController : DragonContractsController
    {
        // GET api/values
        public async Task<IList<Contract>> Get()
        {
            if (await Session.Query<Contract>().AnyAsync() == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    var address = new Address()
                    {
                        City = "City" + i,
                        Number = i.ToString(),
                        Street = "Street" + i,
                        ZipCode = i.ToString()
                    };

                    var firstContact = new Contact()
                    {
                        Address = address,
                        Name = "first " + i
                    };

                    var secondContact = new Contact()
                    {
                        Address = address,
                        Name = "Second " + i
                    };

                    var contract = new Contract()
                    {
                        Id = i.ToString(),
                        FirstParty = firstContact,
                        SecondParty = secondContact,
                        Price = i * 10,
                        SignedOn = DateTime.Now.AddDays(-1 * i),
                        Subject = "Subject " + i
                    };

                    await Session.StoreAsync(contract, i.ToString());
                    await Session.SaveChangesAsync();
                }
            }

            var result = Session.Query<Contract>().ToListAsync();

            return await result;
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