using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

using GoDataFeed.WebSite.App_Start;
using GoDataFeed.Dal;
using SimpleInjector;

namespace GoDataFeed.WebSite
{
    public class Global : HttpApplication
    {
        public static Container simpleInjectionContainer { get; private set; }

        private static void BootstrapSimpleInjector()
        {
            var container = new Container();

            container.Register<IGoDataFeedEfService, GoDataFeedEfService>();
            container.Register<IGoDataFeedDapperService, GoDataFeedDapperService>();
            
            container.Verify();

            Global.simpleInjectionContainer = container;
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GDFBundleConfig.RegisterBundles(BundleTable.Bundles);

            // The database tables already exist
            var strategy = new System.Data.Entity.NullDatabaseInitializer<GoDataFeedContext>();
            Database.SetInitializer<GoDataFeedContext>(strategy);

            BootstrapSimpleInjector();

        }
    }
}