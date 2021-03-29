using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BIMFall4
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //lite info
        //global.asax allows you to write code that runs in response to "system level" events, 
        //such as the application starting, a session ending, an application error occuring, without having to 
        //try and shoe-horn that code into each and every page of your site.

        //Application_Start: Fired when the first instance of the HttpApplication class is created.
        //    It allows you to create objects that are accessible by all HttpApplication instances.
        protected void Application_Start()
        {
            //lagt in detta för formatera
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
