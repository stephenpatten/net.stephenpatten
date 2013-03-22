using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using NavigationRouteFilterExamples;
using NavigationRoutes;
using net.stephenpatten.Controllers;

namespace BootstrapMvcSample
{
    public class BootstrapRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // this enables menu suppression for routes with a FilterToken of "admin" set
            NavigationRouteFilters.Filters.Add(new AdministrationRouteFilter());

            routes.MapNavigationRoute<HomeController>("Automatic Scaffolding", c => c.Index(), "", new NavigationRouteOptions {HasBreakAfter = true});

            // this route will only show if users are in the role specified in the AdministrationRouteFilter
            // by default, when you run the site, you will not see this. Explore the AdministrationRouteFilter
            // class for more information.
            routes.MapNavigationRoute<HomeController>("Administration Menu", c => c.Admin(), "", new NavigationRouteOptions { HasBreakAfter = true, FilterToken = "admin"});

            routes.MapNavigationRoute<ExampleLayoutsController>("Example Layouts", c => c.Null())
                  .AddChildRoute<ExampleLayoutsController>("Marketing", c => c.Marketing())
                  .AddChildRoute<ExampleLayoutsController>("Fluid", c => c.Fluid(), new NavigationRouteOptions{ HasBreakAfter = true})
                  .AddChildRoute<ExampleLayoutsController>("Sign In", c => c.SignIn());

            routes.MapNavigationRoute<GridController>("Example Grids", c => c.Null())
                .AddChildRoute<GridController>("jqGrid", c => c.JQGrid())
                .AddChildRoute<GridController>("DataTables", c => c.DataTable())
                .AddChildRoute<GridController>("SlickGrid", c => c.SlickGrid());

            routes.MapNavigationRoute<DataBindingController>("Example Frameworks", c => c.Null())
                .AddChildRoute<DataBindingController>("AngularJS", c => c.AngularJS())
                .AddChildRoute<DataBindingController>("KnockoutJS", c => c.KnockoutJS());
        }
    }
}
