using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace Login
{
    public class Global : HttpApplication
    {
        private static controller _verwalter;

        public static controller Verwalter { get => _verwalter; set => _verwalter = value; }

        public Global():base()
        {
            Verwalter = new controller();
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code, der beim Anwendungsstart ausgeführt wird
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Verwalter = new controller();
        }
    }
}