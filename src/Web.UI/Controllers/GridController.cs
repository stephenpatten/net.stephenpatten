using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.UI.Extensions;
using Web.UI.Infrastructure.Attributes;
using Web.UI.Infrastructure.Common;
using Web.UI.Models;
using Raven.Client.Linq;
using Web.UI.ViewModel;

namespace Web.UI.Controllers
{
    public class GridController : RavenController
    {
        public const int DefaultPage = 1;
        public const int PageSize = 50;

        protected int CurrentPage
        {
            get
            {
                var s = Request.QueryString["page"];
                int result;
                if (int.TryParse(s, out result))
                    return Math.Max(DefaultPage, result);
                return DefaultPage;
            }
        }

        public ActionResult DataTable()
        {
            return View();
        }

        public ActionResult SlickGrid()
        {
            return View();
        }

        [JsonpFilter]
        public JsonResult ProductData(SlickGridParamModel vm)
        {
            RavenQueryStatistics stats;
            var products = RavenSession.Query<Product>()
                .Statistics(out stats)
                .Search(x => x.INFO2, vm.Query)
                .Paging(CurrentPage, DefaultPage, PageSize)
                .ToList();

            var jsonData = new
                               {
                                   count = PageSize,
                                   total = stats.TotalResults,
                                   rows = (from p in products
                                            select new 
                                              {
                                                p.ProductId
                                              }).ToArray()
                               };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
