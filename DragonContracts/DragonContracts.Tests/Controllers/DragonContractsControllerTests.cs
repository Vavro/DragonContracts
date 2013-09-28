using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.Routing;
using DragonContracts.Base;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Listeners;
using Rhino.Mocks;

namespace DragonContracts.Tests.Controllers
{
    public abstract class DragonContractsControllerTests : IDisposable
    {
        private readonly EmbeddableDocumentStore documentStore;
        protected HttpControllerContext ControllerContext { get; set; }

        protected DragonContractsControllerTests()
        {
            documentStore = new EmbeddableDocumentStore
                            {
                                RunInMemory = true
                            };

            documentStore.RegisterListener(new NoStaleQueriesAllowed());
            documentStore.Initialize();
        }

        protected void SetupData(Action<IDocumentSession> action)
        {
            using (var session = documentStore.OpenSession())
            {
                action(session);
                session.SaveChanges();
            }
        }

        public void Dispose()
        {
            documentStore.Dispose();
        }

        protected async Task ExecuteAction<TController>(Func<TController,Task> action) 
            where TController: DragonContractsController, new()
        {
            var controller = new TController {Session = documentStore.OpenAsyncSession()};

            //var httpConfiguration = MockRepository.GenerateStub<HttpConfiguration>();
            //var httpRouteData = MockRepository.GenerateStub<HttpRouteData>();
            //var httpRequestMessage = MockRepository.GenerateStub<HttpRequestMessage>();
            //ControllerContext = new HttpControllerContext(httpConfiguration, httpRouteData, httpRequestMessage);
            //controller.ControllerContext = ControllerContext;
            
            await action(controller);

            await controller.Session.SaveChangesAsync();
        }
    }

    public class NoStaleQueriesAllowed : IDocumentQueryListener
    {
        public void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
        {
            queryCustomization.WaitForNonStaleResults();
        }
    }
}
