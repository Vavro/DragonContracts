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

namespace DragonContracts.Tests.Controllers
{
    [TestClass]
    public class ContractsControllerTest
    {
        [TestMethod]
        public async Task Get()
        {
            // Arrange
            ContractsController controller = new ContractsController();

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));

        }

        [TestMethod]
        public async Task GetById()
        {
            // Arrange
            ContractsController controller = new ContractsController();

            // Act
            var result = await controller.Get(5);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual("value", result);
        }

        [TestMethod]
        public async Task Post()
        {
            // Arrange
            ContractsController controller = new ContractsController();

            var value = new Contract()
            {
                Id = 5.ToString(),
                Price = 1,
                SignedOn = DateTime.Now,
                Subject = "test",
                FirtsParty = new Contact()
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
            ContractsController controller = new ContractsController();
            
            var value = new Contract()
            {
                Id = 5.ToString(),
                Price = 1,
                SignedOn = DateTime.Now,
                Subject = "test",
                FirtsParty = new Contact()
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
            await controller.Put(5, value);

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ContractsController controller = new ContractsController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
