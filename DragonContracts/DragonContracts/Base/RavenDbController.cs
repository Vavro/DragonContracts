using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using DragonContracts.Indexes;
using DragonContracts.Models;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Raven.Database.Config;
using Raven.Database.Server.Responders;

namespace DragonContracts.Base
{
    public abstract class RavenDbController : ApiController
    {
        private const int RavenWebUiPort = 8081;

        public IDocumentStore Store { get { return LazyDocStore.Value; } }

        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            var docStore = new EmbeddableDocumentStore()
            {
                DataDirectory = "App_Data/Raven",
                UseEmbeddedHttpServer = true,
                Configuration = { Port = RavenWebUiPort }
            };

            Raven.Database.Server.NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(RavenWebUiPort);

            docStore.Initialize();

            IndexCreation.CreateIndexes(typeof(Contracts_SubjectAndNames).Assembly, docStore);

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