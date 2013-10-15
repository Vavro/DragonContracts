using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DragonContracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonContracts;
using DragonContracts.Controllers;
using Raven.Client;

namespace DragonContracts.Tests.Controllers
{
    [TestClass]
    public class ContractsControllerTest : DragonContractsControllerTests
    {
        [TestMethod]
        public async Task Get()
        {
            IList<Contract> result = new List<Contract>();

            SetupData(AddDataToSession);
            await ExecuteAction<ContractsController>(async (controller) => result = await controller.Get());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));

        }

        private void AddDataToSession(IDocumentSession session)
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

                session.Store(contract, i.ToString());
                session.SaveChanges();
            }
        }

        
    }
}
