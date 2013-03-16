using System.Web.Mvc;

namespace Web.UI.Areas.BootstrapLite
{
    public class BootstrapLiteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BootstrapLite";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BootstrapLite_default",
                "BootstrapLite/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
