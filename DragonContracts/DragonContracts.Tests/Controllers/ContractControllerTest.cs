using System;
using System.Threading.Tasks;
using DragonContracts.Controllers.Api;
using DragonContracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonContracts.Tests.Controllers
{
    [TestClass]
    public class ContractControllerTest : DragonContractsControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public async Task GetById()
        {
            // Arrange
            ContractController controller = new ContractController();

            // Act
            var result = await controller.Get("5");

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual("value", result);
        }

        [TestMethod]
        public async Task Post()
        {
            // Arrange
            ContractController controller = new ContractController();

            var value = new Contract()
            {
                Id = 5.ToString(),
                Price = 1,
                SignedOn = DateTime.Now,
                Subject = "test",
                FirstParty = new Contact()
                {
                    Address = new Address()
                    {
                        City = "test city",
                        Number = "1",
                        Street = "street",
                        ZipCode = "12345"
                    },
                    Name = "contact 1"
                },
                SecondParty = new Contact()
                {
                    Address = new Address()
                    {
                        City = "test city 2",
                        Number = "2",
                        Street = "street 1",
                        ZipCode = "23456"
                    },
                    Name = "contact 2"
                }
            };

            // Act
            await controller.Post(value);

            // Assert
            //TODO
        }

        [TestMethod]
        public async Task Put()
        {
            // Arrange
            ContractController controller = new ContractController();

            var value = new Contract()
            {
                Id = 5.ToString(),
                Price = 1,
                SignedOn = DateTime.Now,
                Subject = "test",
                FirstParty = new Contact()
                {
                    Address = new Address()
                    {
                        City = "test city",
                        Number = "1",
                        Street = "street",
                        ZipCode = "12345"
                    },
                    Name = "contact 1"
                },
                SecondParty = new Contact()
                {
                    Address = new Address()
                    {
                        City = "test city 2",
                        Number = "2",
                        Street = "street 1",
                        ZipCode = "23456"
                    },
                    Name = "contact 2"
                }
            };
            // Act
            await controller.Put("5", value);

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ContractController controller = new ContractController();

            // Act
            controller.Delete("5");

            // Assert
        }
    }
}
