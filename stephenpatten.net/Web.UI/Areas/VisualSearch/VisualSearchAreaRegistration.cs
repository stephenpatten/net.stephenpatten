using System.Web.Mvc;

namespace Web.UI.Areas.VisualSearch
{
    public class VisualSearchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VisualSearch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VisualSearch_default",
                "VisualSearch/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
