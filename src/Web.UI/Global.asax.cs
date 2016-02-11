using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Web.UI.Controllers;
using Web.UI.Infrastructure.Indexes;

namespace Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static IDocumentStore DocumentStore { get; private set; }

        private static void InitializeDocumentStore()
        {
            if (DocumentStore != null) return; // prevent misuse

            DocumentStore = new EmbeddableDocumentStore
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();

            TryCreatingIndexesOrRedirectToErrorPage();
        }

        public MvcApplication()
        {
            BeginRequest += (sender, args) =>
            {
                HttpContext.Current.Items["CurrentRequestRavenSession"] = RavenController.DocumentStore.OpenSession();
            };
            EndRequest += (sender, args) =>
            {
                using (var session = (IDocumentSession)HttpContext.Current.Items["CurrentRequestRavenSession"])
                {
                    if (session == null)
                        return;

                    if (Server.GetLastError() != null)
                        return;

                    session.SaveChanges();
                }
            };
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            InitializeDocumentStore();

            RegisterRoutes(RouteTable.Routes);

            RavenController.DocumentStore = DocumentStore;
        }

        private static void TryCreatingIndexesOrRedirectToErrorPage()
        {
            IndexCreation.CreateIndexes(typeof(Products_Index).Assembly, DocumentStore);
        }
    }
}