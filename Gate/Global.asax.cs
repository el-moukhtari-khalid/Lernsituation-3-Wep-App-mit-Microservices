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

namespace Gate
{
    public class Global : HttpApplication
    {
        #region Eigenschaften
        private static controller _verwalter;

        #endregion

        #region Accessoren/Modifier
        public static controller Verwalter { get => _verwalter; set => _verwalter = value; }

        #endregion

        #region Konstruktoren
        public Global():base()
        {
            Verwalter = new controller();
        }
        #endregion

        #region Worker
        void Application_Start(object sender, EventArgs e)
        {
            // Code, der beim Anwendungsstart ausgeführt wird
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Verwalter = new controller();
            
        }

        #endregion

    }
}