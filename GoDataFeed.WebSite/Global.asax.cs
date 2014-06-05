using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using GoDataFeed.WebSite.App_Start;

using GoDataFeed.Dal;

namespace GoDataFeed.WebSite
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GDFBundleConfig.RegisterBundles(BundleTable.Bundles);

            // The database tables already exist
            var productStrategy = new System.Data.Entity.NullDatabaseInitializer<ProductContext>();
            Database.SetInitializer<ProductContext>(productStrategy);

            var retailerStrategy = new System.Data.Entity.NullDatabaseInitializer<RetailerContext>();
            Database.SetInitializer<RetailerContext>(retailerStrategy);

        }
    }
}