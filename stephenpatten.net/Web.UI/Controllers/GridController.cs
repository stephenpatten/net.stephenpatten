using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI.Controllers
{
    public class GridController : Controller
    {
        //
        // GET: /Grid/

        public ActionResult DataTable()
        {
            return View();
        }

        public ActionResult SlickGrid()
        {
            return View();
        }
        
    }
}
