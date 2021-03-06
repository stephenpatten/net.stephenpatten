﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MvcApplication5;

namespace net.stephenpatten
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BootstrapMvcSample.BootstrapRouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}