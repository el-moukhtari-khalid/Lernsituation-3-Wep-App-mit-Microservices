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

namespace Personenverwaltung
{
    public class Global : HttpApplication
    {
        #region Eigenschaften
        private static Controller _verwalter;


        #endregion

        #region Accessoren/Modifier
        public static Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        #endregion

        #region Konstruktoren
        public Global():base()
        {
            Verwalter = new Controller();
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
            Verwalter = new Controller();

        }
        #endregion

    }
}