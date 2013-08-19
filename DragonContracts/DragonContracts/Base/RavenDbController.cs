using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using DragonContracts.Models;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Database.Server.Responders;

namespace DragonContracts.Base
{
    public class RavenDbController : ApiController
    {
        public IDocumentStore Store { get { return LazyDocStore.Value; } }

        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            var docStore = new EmbeddableDocumentStore();

            docStore.Initialize();

            using (var session = docStore.OpenSession())
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
                        Id = i,
                        FirtsParty = firstContact,
                        SecondParty = secondContact,
                        Price = i * 10,
                        SignedOn = DateTime.Now.AddDays(-1 * i),
                        Subject = "Subject " + i
                    };

                    session.Store(contract, i.ToString());
                }

            }

            return docStore;
        });

        public IAsyncDocumentSession Session { get; set; }

        public async override Task<HttpResponseMessage> ExecuteAsync(
                                                            HttpControllerContext controllerContext,
                                                            CancellationToken cancellationToken)
        {
            using (Session = Store.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();

                return result;
            }
        }
    }
}