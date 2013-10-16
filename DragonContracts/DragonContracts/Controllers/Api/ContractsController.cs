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
            //await AddTestData();

            var result = Session.Query<Contract>().ToListAsync();

            return await result;
        }

        private async Task AddTestData()
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
                        Price = i*10,
                        SignedOn = DateTime.Now.AddDays(-1*i),
                        Subject = "Subject " + i
                    };

                    await Session.StoreAsync(contract, i.ToString());
                    await Session.SaveChangesAsync();
                }
            }
        }

        // GET api/contracts/filter
        public async Task<IList<Contract>> Get(string filter)
        {
            //todo: filter by subject, contact names now just return all
            return await Session.Query<Contract>().ToListAsync();
        }

       
    }
}